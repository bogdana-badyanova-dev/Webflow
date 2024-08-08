using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Webflow.API.Dto.Import;
using Webflow.API.Dto.Shared;
using Webflow.Application.Enums;
using Webflow.Application.Interfaces;
using Webflow.Application.Interfaces.Import;
using Webflow.Application.Services.FilesService.Interfaces;

namespace Webflow.API.Controllers.Import
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportController : ControllerBase
    {
        private readonly IImportStrategyFactory<ImportResult> importStrategyFactory;
        private readonly IFilesService filesService;

        public ImportController(IImportStrategyFactory<ImportResult> importStrategyFactory, IFilesService filesService)
        {
            this.importStrategyFactory = importStrategyFactory;
            this.filesService = filesService;
        }

        // TODO Вытащить в сервис всю логику
        [HttpPost("import-preview")]
        public async Task<ActionResult<BaseResponse<ExcelImportResult>>> ImportPreviewExcelFile(IFormFile file, CancellationToken cancellationToken, int previewRowsCount = 5)
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
                return BadRequest(response);
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
                        return BadRequest(response);
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

                    var result = new ExcelImportResult
                    {
                        FileId = uploadResult.Data,
                        Headers = headers,
                        PreviewRows = previewRows
                    };

                    return Ok(new BaseResponse<ExcelImportResult>
                    {
                        IsSuccess = true,
                        Data = result
                    });
                }
            }
        }

        /// <summary>
        /// Импортирует данные из файла с учетом маппинга полей
        /// </summary>
        /// <param name="fileId">ID файла для импорта</param>
        /// <param name="platform">Платформа источника данных</param>
        /// <param name="mappings">Маппинг полей модели и столбцов файла</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Результат импорта в формате ExcelImportResult</returns>
        [HttpPost("import")]
        public async Task<ActionResult<ImportResult>> ImportExcelFile(
            [FromForm] Guid fileId,
            [FromForm] PlatformEnum platform,
            [FromForm] IEnumerable<FieldMapping> mappings,
            CancellationToken cancellationToken)
        {
            var strategy = importStrategyFactory.CreateStrategy(platform);

            var result = await strategy.Import(fileId, mappings, cancellationToken);

            return Ok(result);
        }
    }
}

