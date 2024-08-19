using Webflow.Application.Enums;

namespace Webflow.Application.Services.NotificationsService.Interfaces
{
    public interface INotificationService
    {
        Task SendNotificationAsync(NotificationType type, string message = null, object content = null);
    }
}
