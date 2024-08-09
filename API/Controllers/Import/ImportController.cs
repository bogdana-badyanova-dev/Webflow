using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto.Import;
using Webflow.API.Dto.Shared;
using Webflow.Application.Enums;
using Webflow.Application.Interfaces;
using Webflow.Application.Interfaces.Import;
using Webflow.Application.Services.Import.Interfaces;

namespace Webflow.API.Controllers.Import
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportController : ControllerBase
    {
        private readonly IImportStrategyFactory<ImportResult> importStrategyFactory;
        private readonly IImportService importService;

        public ImportController(IImportStrategyFactory<ImportResult> importStrategyFactory, IImportService importService)
        {
            this.importStrategyFactory = importStrategyFactory;
            this.importService = importService;
        }

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
            Guid fileId,
            PlatformEnum platform,
            IEnumerable<FieldMapping> mappings,
            CancellationToken cancellationToken)
        {
            var strategy = importStrategyFactory.CreateStrategy(platform);

            var result = await strategy.Import(fileId, mappings, cancellationToken);

            return Ok(result);
        }
    }
}

