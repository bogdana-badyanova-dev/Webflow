using Webflow.Application.Enums;

namespace Webflow.Application.Interfaces.Notifications
{
    /// <summary>
    /// Уведомление, содержащее текстовое сообщение.
    /// </summary>
    public class TextNotification : Notification
    {
        /// <summary>
        /// Получает или задает текстовое сообщение уведомления.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Создает уведомление с указанным текстовым сообщением.
        /// </summary>
        /// <param name="message">Текстовое сообщение уведомления.</param>
        public TextNotification(string message)
        {
            Type = NotificationType.Text;
            Message = message;
        }
    }
}
