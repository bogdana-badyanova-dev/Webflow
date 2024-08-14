using Webflow.Application.Enums;

namespace Webflow.Application.Interfaces.Notifications
{
    public class ObjectNotification<T> : Notification
    {
        public T Object { get; set; }

        public ObjectNotification(T obj)
        {
            Type = NotificationType.Object;
            Object = obj;
        }
    }
}
