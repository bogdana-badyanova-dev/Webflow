using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto.Import;
using Webflow.API.Dto.Shared;

namespace Webflow.API.Controllers.Import
{
    public partial class ImportController : ControllerBase
    {
        /// <summary>
        /// Импортирует предварительный просмотр данных из загруженного Excel-файла
        /// </summary>
        /// <param name="file">Excel-файл, содержащий данные для импорта</param>
        /// <param name="cancellationToken">Токен для отмены асинхронной операции</param>
        /// <param name="previewRowsCount">Количество строк для предварительного просмотра. По умолчанию 5</param>
        /// <returns>Результат запроса, содержащий данные предварительного просмотра и статус операции</returns>
        /// <response code="200">Успешное выполнение запроса. Возвращает предварительный просмотр данных из Excel-файла</response>
        /// <response code="400">Запрос выполнен с ошибкой. Возвращает информацию об ошибках выполнения</response>
        [HttpPost("import-preview")]
        public async Task<ActionResult<BaseResponse<ExcelImportResult>>> ImportPreviewExcelFile(IFormFile file, CancellationToken cancellationToken, int previewRowsCount = 5)
        {
            var result = await importService.ImportPreviewExcelFile(file, cancellationToken, previewRowsCount);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}

