using Webflow.Application.Enums;

namespace Webflow.Application.Interfaces.Notifications
{
    public class TextNotification : Notification
    {
        public string Message { get; set; }

        public TextNotification(string message)
        {
            Type = NotificationType.Text;
            Message = message;
        }
    }
}
