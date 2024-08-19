using Webflow.Application.Enums;

namespace Webflow.Application.Interfaces.Notifications
{
    public abstract class Notification
    {
        public NotificationType Type { get; set; }
    }
}
