using Webflow.Application.Enums;

namespace Webflow.Application.Interfaces.Notifications
{
    /// <summary>
    /// Уведомление, содержащее текстовое сообщение с предупреждением.
    /// </summary>
    public class WarningNotification : TextNotification
    {
        /// <summary>
        /// Создает уведомление с указанным текстовым сообщением предупреждения.
        /// </summary>
        /// <param name="message">Текстовое сообщение предупреждения.</param>
        public WarningNotification(string message)
            : base(message)
        {
            Type = NotificationType.Warning;
        }
    }
}
