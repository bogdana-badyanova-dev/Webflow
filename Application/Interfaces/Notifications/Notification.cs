using Webflow.Application.Enums;

namespace Webflow.Application.Interfaces.Notifications
{
    /// <summary>
    /// Абстрактный базовый класс для уведомлений
    /// </summary>
    public abstract class Notification
    {
        /// <summary>
        /// Тип уведомления
        /// </summary>
        public NotificationType Type { get; set; }
    }
}
