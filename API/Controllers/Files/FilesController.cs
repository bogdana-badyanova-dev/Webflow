using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Webflow.Application.Interfaces;
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
        private readonly ConnectionFactory _factory;

        /// <summary>
        /// Конструктор контроллера для работы с файлами
        /// </summary>
        /// <param name="filesService">Сервис для работы с файлами</param>
        public FilesController(IFilesService filesService)
        {
            this.filesService = filesService;
            _factory = new ConnectionFactory() { HostName = "localhost" };
        }

        // POST api/rabbitmq/send
        [HttpPost("send")]
        public IActionResult SendMessage([FromBody] string message)
        {
            using (var connection = _factory.CreateConnection())
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

        // GET api/rabbitmq/receive
        [HttpGet("receive")]
        public IActionResult ReceiveMessage()
        {
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                string message = null;

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    message = Encoding.UTF8.GetString(body);
                };

                channel.BasicConsume(queue: "hello",
                                     autoAck: true,
                                     consumer: consumer);

                // Немного подождем, пока сообщение будет получено
                System.Threading.Thread.Sleep(5000);

                if (message == null)
                    return NotFound(new { Message = "No messages in queue" });

                return Ok(new { Message = "Message received", Content = message });
            }
        }
    }
}
