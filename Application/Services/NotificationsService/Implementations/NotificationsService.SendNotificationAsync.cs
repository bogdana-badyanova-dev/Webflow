using Microsoft.AspNetCore.SignalR;
using Webflow.Application.Enums;
using Webflow.Application.Services.NotificationsService.Interfaces;

namespace Webflow.Application.Services.NotificationsService.Implementations
{
    public partial class NotificationService : INotificationService
    {
        /// <summary>
        /// Отправляет уведомление асинхронно.
        /// </summary>
        /// <param name="type">Тип уведомления.</param>
        /// <param name="message">Текст сообщения (необязательно).</param>
        /// <param name="content">Объект содержимого уведомления (необязательно).</param>
        /// <returns>Задача, представляющая асинхронную операцию отправки уведомления.</returns>
        public async Task SendNotificationAsync(NotificationType type, string message = null, object content = null)
        {
            var notification = notificationFactory.CreateNotification(type, message, content);
            await hubContext.Clients.All.SendAsync("ReceiveNotification", notification);
        }
    }
}
