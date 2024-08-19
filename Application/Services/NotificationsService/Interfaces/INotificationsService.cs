using Webflow.Application.Enums;

namespace Webflow.Application.Services.NotificationsService.Interfaces
{
    /// <summary>
    /// Интерфейс для сервиса отправки уведомлений.
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// Отправляет уведомление асинхронно.
        /// </summary>
        /// <param name="type">Тип уведомления.</param>
        /// <param name="message">Текст сообщения (необязательно).</param>
        /// <param name="content">Объект содержимого уведомления (необязательно).</param>
        /// <returns>Задача, представляющая асинхронную операцию отправки уведомления.</returns>
        public Task SendNotificationAsync(NotificationType type, string message = null, object content = null);
    }
}
