using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Webflow.API.Dto.Import;
using Webflow.Application.Enums;
using Webflow.Application.Helpers;
using Webflow.Application.Interfaces;
using Webflow.Application.Interfaces.Import;
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
                            var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();

                            var importStrategyFactory = scope.ServiceProvider.GetRequiredService<IImportStrategyFactory<IImportResult>>();
                            var importStrategy = importStrategyFactory.CreateStrategy(data.Platform);
                            var importModel = await importStrategy.Import(data.FileId, data.Mappings);

                            //var importValidateStrategyFactory = scope.ServiceProvider.GetRequiredService<ImportValidationStrategyFactory>();
                            //var validateStrategy = importValidateStrategyFactory.CreateStrategy(data.Platform);
                            //var validationResult = await validateStrategy.Validate(importModel);

                            //if (!validationResult.IsSuccess)
                            //{
                            //    await notificationService.SendNotificationAsync(NotificationType.Object, null, validationResult);
                            //}
                            //else
                            //{


                                //TODO
                                //для МУДЛА
                                //сохранить проверить студента, 
                                //сохранить проверить курс,
                                //сохранить элементы для курса
                                //сохранить результаты студента(элементы курса)
                                //посчитать итоговые баллы по элементам курса
                                //
                                //
                                //для ИННОПОЛИС
                                //сохранить проверить студента, 
                                //сохранить проверить курс,
                                //сохранить компитенции
                                // результат по каждой компитенции
                                //

                                await notificationService.SendNotificationAsync(NotificationType.Success, "Обработан");
                            //}

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
