using Microsoft.AspNetCore.SignalR;
using Webflow.API.Hubs;
using Webflow.Application.Interfaces.Notifications;
using Webflow.Application.Services.NotificationsService.Interfaces;

namespace Webflow.Application.Services.NotificationsService.Implementations
{
    /// <summary>
    /// Сервис для отправки уведомлений, реализующий интерфейс <see cref="INotificationService"/>.
    /// </summary>
    public partial class NotificationService : INotificationService
    {
        private readonly IHubContext<NotificationHub> hubContext;
        private readonly INotificationFactory notificationFactory;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="NotificationService"/>.
        /// </summary>
        /// <param name="hubContext">Контекст хаба SignalR для отправки уведомлений клиентам.</param>
        /// <param name="notificationFactory">Фабрика для создания уведомлений.</param>
        public NotificationService(IHubContext<NotificationHub> hubContext, INotificationFactory notificationFactory)
        {
            this.hubContext = hubContext;
            this.notificationFactory = notificationFactory;
        }
    }
}
