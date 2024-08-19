using Webflow.Application.Enums;

namespace Webflow.Application.Interfaces.Notifications
{
    /// <summary>
    /// Интерфейс фабрики уведомлений, предназначенный для создания уведомлений различного типа
    /// </summary>
    public interface INotificationFactory
    {
        /// <summary>
        /// Создает уведомление на основе заданного типа, сообщения и дополнительного содержимого
        /// </summary>
        /// <param name="type">Тип уведомления</param>
        /// <param name="message">Сообщение уведомления</param>
        /// <param name="content">Дополнительное содержимое уведомления</param>
        /// <returns>Созданное уведомление</returns>
        Notification CreateNotification(NotificationType type, string message, object content);
    }
}
