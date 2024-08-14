using Webflow.Application.Enums;

namespace Webflow.Application.Interfaces.Notifications
{
    public class ErrorNotification : TextNotification
    {
        public ErrorNotification(string message)
            : base(message)
        {
            Type = NotificationType.Error;
        }
    }
}
