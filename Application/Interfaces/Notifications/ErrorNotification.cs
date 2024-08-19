using Webflow.Application.Enums;

namespace Webflow.Application.Interfaces.Notifications
{
    /// <summary>
    /// Представляет собой уведомление об ошибке с заданным сообщением
    /// </summary>
    public class ErrorNotification : TextNotification
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ErrorNotification"/> с заданным сообщением
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        public ErrorNotification(string message)
            : base(message)
        {
            Type = NotificationType.Error;
        }
    }
}
