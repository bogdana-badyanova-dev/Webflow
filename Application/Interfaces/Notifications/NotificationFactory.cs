using Webflow.Application.Enums;

namespace Webflow.Application.Interfaces.Notifications
{
    /// <summary>
    /// Фабрика для создания уведомлений различных типов
    /// </summary>
    public class NotificationFactory : INotificationFactory
    {
        /// <summary>
        /// Создает уведомление в зависимости от типа
        /// </summary>
        /// <param name="type">Тип уведомления</param>
        /// <param name="message">Сообщение уведомления</param>
        /// <param name="content">Содержание уведомления (для объектов)</param>
        /// <returns>Созданное уведомление</returns>
        public Notification CreateNotification(NotificationType type, string message = null, object content = null)
        {
            return type switch
            {
                NotificationType.Text => new TextNotification(message),
                NotificationType.Object => new ObjectNotification<object>(content),
                NotificationType.Warning => new WarningNotification(message),
                NotificationType.Error => new ErrorNotification(message),
                NotificationType.Info => new InfoNotification(message),
                NotificationType.Success => new SuccessNotification(message),
                _ => throw new ArgumentException("Invalid notification type", nameof(type)),
            };
        }
    }
}
