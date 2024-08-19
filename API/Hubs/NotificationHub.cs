using Microsoft.AspNetCore.SignalR;

namespace Webflow.API.Hubs
{
    /// <summary>
    /// Класс, представляющий хаб для отправки уведомлений
    /// </summary>
    public class NotificationHub : Hub
    {
        /// <summary>
        /// Отправляет уведомление всем подключенным клиентам
        /// </summary>
        /// <param name="message">Сообщение для отправки</param>
        /// <returns>Задача, представляющая асинхронную операцию</returns>
        public async Task SendNotification(string message)
        {
            await Clients.All.SendAsync("ReceiveNotification", message);
        }
    }
}
