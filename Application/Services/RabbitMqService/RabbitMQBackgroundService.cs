using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Webflow.API.Dto.Import;
using Webflow.Application.Enums;
using Webflow.Application.Helpers;
using Webflow.Application.Interfaces.Import;
using Webflow.Application.Interfaces;
using Webflow.Application.Services.NotificationsService.Interfaces;
using System.Threading;

public class RabbitMQBackgroundService : BackgroundService
{
    private readonly ConnectionFactory factory;
    private readonly IServiceProvider serviceProvider;

    public RabbitMQBackgroundService(ConnectionFactory factory, IServiceProvider serviceProvider)
    {
        this.factory = factory;
        this.serviceProvider = serviceProvider;
    }

    public class ImportMessage
    {
        public Guid FileId { get; set; }
        public PlatformEnum Platform { get; set; }
        public IEnumerable<FieldMapping> Mappings { get; set; }
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Task.Run(() =>
        {
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body.ToArray();

                    var message = Encoding.UTF8.GetString(body);

                    var data = JsonConvert.DeserializeObject<ImportMessage>(message);

                    using (var scope = serviceProvider.CreateScope())
                    {
                        var importStrategyFactory = scope.ServiceProvider.GetRequiredService<IImportStrategyFactory<IImportResult>>();
                        var strategy = importStrategyFactory.CreateStrategy(data.Platform);
                        var result = await strategy.Import(data.FileId, data.Mappings);

                        var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();
                        await notificationService.SendNotificationAsync(NotificationType.Object, null, result);
                    }

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
