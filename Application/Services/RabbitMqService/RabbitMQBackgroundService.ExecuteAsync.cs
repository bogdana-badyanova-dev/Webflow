using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Webflow.API.Dto.Import;
using Webflow.Application.Enums;
using Webflow.Application.Interfaces.Import;
using Webflow.Application.Interfaces;
using Webflow.Application.Services.NotificationsService.Interfaces;

public partial class RabbitMQBackgroundService : BackgroundService
{
    /// <summary>
    /// Метод выполняет фоновые задачи для службы, используя RabbitMQ для обработки сообщений из очереди.
    /// </summary>
    /// <param name="stoppingToken">Токен отмены, используемый для остановки выполнения фоновой задачи.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Task.Run(() =>
        {
            try
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

                        var data = JsonConvert.DeserializeObject<ImportProvideData>(message);

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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to RabbitMQ: {ex.Message}");
            }
        }, stoppingToken);
    }
}
