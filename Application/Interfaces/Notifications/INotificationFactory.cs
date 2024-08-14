using Webflow.Application.Enums;

namespace Webflow.Application.Interfaces.Notifications
{
    public interface INotificationFactory
    {
        Notification CreateNotification(NotificationType type, string message, object content);
    }
}
