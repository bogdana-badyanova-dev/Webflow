using Webflow.Application.Enums;

namespace Webflow.Application.Interfaces.Notifications
{
    public class WarningNotification : TextNotification
    {
        public WarningNotification(string message)
            : base(message)
        {
            Type = NotificationType.Warning;
        }
    }
}
