using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto.Import;
using Webflow.Application.Enums;
using Webflow.Application.Interfaces;

namespace Webflow.API.Controllers.Import
{
    public partial class ImportController : ControllerBase
    {
        /// <summary>
        /// Импортирует данные из Excel-файла на основе переданных параметров.
        /// </summary>
        /// <param name="fileId">Идентификатор файла, содержащего данные для импорта.</param>
        /// <param name="platform">Платформа, для которой выполняется импорт (например, Moodle, Иннополис и т.д.).</param>
        /// <param name="mappings">Массив сопоставлений полей, указывающий, как данные из Excel-файла должны быть сопоставлены с полями модели.</param>
        /// <param name="cancellationToken">Токен для отмены асинхронной операции импорта.</param>
        /// <returns>Результат операции импорта, содержащий информацию о статусе выполнения и данные результата.</returns>
        /// <response code="200">Успешное выполнение запроса. Возвращает результат импорта данных из Excel-файла.</response>
        /// <response code="400">Запрос выполнен с ошибкой. Возвращает информацию об ошибках выполнения операции импорта.</response>
        [HttpPost("import")]
        public async Task<ActionResult<IImportResult>> ImportExcelFile(
            Guid fileId,
            PlatformEnum platform,
            IEnumerable<FieldMapping> mappings,
            CancellationToken cancellationToken)
        {
            var result = await importService.ImportExcelFile(fileId, platform, mappings, cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}

