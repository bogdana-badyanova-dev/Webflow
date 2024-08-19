using Webflow.Application.Enums;

namespace Webflow.Application.Interfaces.Notifications
{
    /// <summary>
    /// Уведомление о успешном выполнении действия, содержащее текстовое сообщение.
    /// </summary>
    public class SuccessNotification : TextNotification
    {
        /// <summary>
        /// Создает уведомление о успешном выполнении действия с указанным сообщением.
        /// </summary>
        /// <param name="message">Текстовое сообщение уведомления.</param>
        public SuccessNotification(string message)
            : base(message)
        {
            Type = NotificationType.Success;
        }
    }
}
