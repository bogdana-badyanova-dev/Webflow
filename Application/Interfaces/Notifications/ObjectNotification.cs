using Webflow.Application.Enums;

namespace Webflow.Application.Interfaces.Notifications
{
    /// <summary>
    /// Уведомление, содержащее объект произвольного типа.
    /// </summary>
    /// <typeparam name="T">Тип объекта, который будет содержаться в уведомлении.</typeparam>
    public class ObjectNotification<T> : Notification
    {
        /// <summary>
        /// Объект, содержащийся в уведомлении.
        /// </summary>
        public T Object { get; set; }

        /// <summary>
        /// Создает уведомление с указанным объектом.
        /// </summary>
        /// <param name="obj">Объект, который будет содержаться в уведомлении.</param>
        public ObjectNotification(T obj)
        {
            Type = NotificationType.Object;
            Object = obj;
        }
    }
}
