using RabbitMQ.Client;

/// <summary>
/// Служба фоновых задач для обработки сообщений из RabbitMQ.
/// </summary>
public partial class RabbitMQBackgroundService : BackgroundService
{
    private readonly ConnectionFactory factory;
    private readonly IServiceProvider serviceProvider;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="RabbitMQBackgroundService"/> с заданной фабрикой подключений и провайдером сервисов.
    /// </summary>
    /// <param name="factory">Фабрика подключений для создания соединений с RabbitMQ.</param>
    /// <param name="serviceProvider">Провайдер сервисов для получения зависимостей.</param>
    public RabbitMQBackgroundService(ConnectionFactory factory, IServiceProvider serviceProvider)
    {
        this.factory = factory;
        this.serviceProvider = serviceProvider;
    }
}
