using Webflow.Application.Enums;

namespace Webflow.Application.Interfaces.Notifications
{
    /// <summary>
    /// Класс для представления информационного уведомления, наследует от <see cref="TextNotification"/>
    /// </summary>
    public class InfoNotification : TextNotification
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="InfoNotification"/> с заданным сообщением
        /// </summary>
        /// <param name="message">Сообщение информации</param>
        public InfoNotification(string message)
            : base(message)
        {
            Type = NotificationType.Info;
        }
    }
}
