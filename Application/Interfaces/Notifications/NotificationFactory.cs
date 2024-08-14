using Webflow.Application.Enums;

namespace Webflow.Application.Interfaces.Notifications
{
    public class NotificationFactory : INotificationFactory
    {
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
