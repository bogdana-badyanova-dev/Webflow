using Webflow.Application.Enums;

namespace Webflow.Application.Interfaces.Notifications
{
    public class InfoNotification : TextNotification
    {
        public InfoNotification(string message)
            : base(message)
        {
            Type = NotificationType.Info;
        }
    }
}
