using Newtonsoft.Json;
using OfficeOpenXml;
using RabbitMQ.Client;
using System.Text;
using Webflow.API.Dto.Import;
using Webflow.API.Dto.Shared;
using Webflow.Application.Enums;
using Webflow.Application.Services.FilesService.Interfaces;
using Webflow.Application.Services.Import.Interfaces;

namespace Webflow.Application.Services.Import.Implementations
{
    /// <summary>
    /// Сервис для обработки импорта данных из Excel файлов.
    /// </summary>
    public class ImportService : IImportService
    {
        private readonly IFilesService filesService;
        private readonly ConnectionFactory factory;

        /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ImportService"/>.
    /// </summary>
    /// <param name="filesService">Сервис для работы с файлами.</param>
    /// <param name="factory">Фабрика для создания соединений с RabbitMQ.</param>
        public ImportService(IFilesService filesService, ConnectionFactory factory)
        {
            this.filesService = filesService;
            this.factory = factory;
        }

        /// <summary>
        /// Импортирует предварительный просмотр данных из Excel файла.
        /// </summary>
        /// <param name="file">Файл Excel для предварительного просмотра.</param>
        /// <param name="cancellationToken">Токен для отмены операции.</param>
        /// <param name="previewRowsCount">Количество строк для предварительного просмотра. По умолчанию 5.</param>
        /// <returns>Результат предварительного просмотра импорта, содержащий информацию о файле и заголовках.</returns>
        public async Task<BaseResponse<ExcelImportResult>> ImportPreviewExcelFile(IFormFile file, CancellationToken cancellationToken, int previewRowsCount = 5)
        {
            var response = new BaseResponse<ExcelImportResult>
            {
                IsSuccess = false,
                ErrorMessages = new List<string>() { }
            };

            if (file == null || file.Length == 0)
            {
                // TODO
                response.ErrorMessages.Append("Нет файла");
                return response;
            }

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream, cancellationToken);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    if (worksheet == null)
                    {
                        // TODO
                        response.ErrorMessages.Append("Нет страниц в файле");
                        return response;
                    }

                    var headers = new List<string>();
                    var previewRows = new List<IDictionary<string, object>>();

                    for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                    {
                        headers.Add(worksheet.Cells[1, col].Text);
                    }

                    for (int row = 2; row <= Math.Min(previewRowsCount + 1, worksheet.Dimension.End.Row); row++)
                    {
                        var rowDict = new Dictionary<string, object>();
                        for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                        {
                            rowDict[headers[col - 1]] = worksheet.Cells[row, col].Text;
                        }
                        previewRows.Add(rowDict);
                    }

                    var uploadResult = await filesService.UploadFile(file, cancellationToken);

                    // TODO проверить uploadResult

                    var result = new ExcelImportResult
                    {
                        FileId = uploadResult.Data,
                        Headers = headers,
                        PreviewRows = previewRows
                    };

                    response.IsSuccess = true;
                    response.Data = result;
                    return response;
                }
            }
        }

        /// <summary>
        /// Импортирует данные из Excel файла.
        /// </summary>
        /// <param name="fileId">Идентификатор файла Excel.</param>
        /// <param name="platform">Платформа, с которой связан файл.</param>
        /// <param name="mappings">Сопоставления полей для импорта данных.</param>
        /// <param name="cancellationToken">Токен для отмены операции.</param>
        /// <returns>Результат импорта, содержащий информацию о результате операции.</returns>
        public async Task<BaseResponse<string>> ImportExcelFile(
            Guid fileId,
            PlatformEnum platform,
            IEnumerable<FieldMapping> mappings,
            CancellationToken cancellationToken)
        {
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var messageObject = new
                {
                    FileId = fileId,
                    Platform = platform,
                    Mappings = mappings,
                    CancellationToken = cancellationToken.IsCancellationRequested
                };

                var data = JsonConvert.SerializeObject(messageObject);

                var body = Encoding.UTF8.GetBytes(data);

                channel.BasicPublish(exchange: "",
                                     routingKey: "hello",
                                     basicProperties: null,
                                     body: body);

                return new BaseResponse<string>()
                {
                    IsSuccess = true,
                    Data = "Файл принят в обработку"
                    
                };
            }
            //var strategy = importStrategyFactory.CreateStrategy(platform);

            //var result = await strategy.Import(fileId, mappings, cancellationToken);

            //await notificationService.SendNotificationAsync(NotificationType.Object,null, result);

            //// TODO тут по итогу должна валидироваться и сохраняться инфа по тем моделям импорта, что мы получили
            //return new BaseResponse<IImportResult>()
            //{
            //    IsSuccess = true,
            //    Data = result
            //};
        }
    }
}
