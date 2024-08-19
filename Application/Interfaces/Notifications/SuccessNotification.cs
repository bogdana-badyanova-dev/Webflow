using Webflow.Application.Enums;

namespace Webflow.Application.Interfaces.Notifications
{
    public class SuccessNotification : TextNotification
    {
        public SuccessNotification(string message)
            : base(message)
        {
            Type = NotificationType.Success;
        }
    }
}
