using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;
using Webflow.Application.Services.FilesService.Interfaces;

namespace Webflow.API.Controllers.Files
{
    /// <summary>
    /// Контроллер для работы с файлами
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public partial class FilesController : ControllerBase
    {
        private readonly IFilesService filesService;
        private readonly ConnectionFactory factory;

        /// <summary>
        /// Конструктор контроллера для работы с файлами
        /// </summary>
        /// <param name="filesService">Сервис для работы с файлами</param>
        public FilesController(IFilesService filesService, ConnectionFactory factory)
        {
            this.filesService = filesService;
            this.factory = factory;
        }

        [HttpPost("send")]
        public IActionResult SendMessage([FromBody] string message)
        {
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "hello",
                                     basicProperties: null,
                                     body: body);

                return Ok(new { Message = "Message sent", Content = message });
            }
        }
    }
}
