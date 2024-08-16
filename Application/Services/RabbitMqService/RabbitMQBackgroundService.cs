using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Webflow.API.Dto.Import;
using Webflow.Application.Enums;

public class RabbitMQBackgroundService : BackgroundService
{
    private readonly ConnectionFactory _factory;

    public RabbitMQBackgroundService(ConnectionFactory factory)
    {
        _factory = factory;
    }

    public class ImportMessage
    {
        public Guid FileId { get; set; }
        public PlatformEnum Platform { get; set; }
        public IEnumerable<FieldMapping> Mappings { get; set; }
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return Task.Run(() =>
        {
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    var data = JsonConvert.DeserializeObject<ImportMessage>(message);

                    Console.WriteLine($"[x] Received message: {data}");
                };

                channel.BasicConsume(queue: "hello",
                                     autoAck: true,
                                     consumer: consumer);

                while (!stoppingToken.IsCancellationRequested)
                {
                    Thread.Sleep(1000);
                }
            }
        }, stoppingToken);
    }
}
