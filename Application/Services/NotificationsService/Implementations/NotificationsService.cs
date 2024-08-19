using Microsoft.AspNetCore.SignalR;
using Webflow.API.Hubs;
using Webflow.Application.Enums;
using Webflow.Application.Interfaces.Notifications;
using Webflow.Application.Services.NotificationsService.Interfaces;

namespace Webflow.Application.Services.NotificationsService.Implementations
{
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<NotificationHub> hubContext;
        private readonly INotificationFactory notificationFactory;

        public NotificationService(IHubContext<NotificationHub> hubContext, INotificationFactory notificationFactory)
        {
            this.hubContext = hubContext;
            this.notificationFactory = notificationFactory;
        }

        public async Task SendNotificationAsync(NotificationType type, string message = null, object content = null)
        {
            var notification = notificationFactory.CreateNotification(type, message, content);
            await hubContext.Clients.All.SendAsync("ReceiveNotification", notification);
        }
    }
}
