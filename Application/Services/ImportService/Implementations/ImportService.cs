using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Webflow.API.Dto.Import;
using Webflow.API.Dto.Shared;
using Webflow.Application.Enums;
using Webflow.Application.Helpers;
using Webflow.Application.Interfaces;
using Webflow.Application.Interfaces.Import;
using Webflow.Application.Services.FilesService.Interfaces;
using Webflow.Application.Services.Import.Interfaces;
using Webflow.Application.Services.NotificationsService.Interfaces;

namespace Webflow.Application.Services.Import.Implementations
{
    public class ImportService : IImportService
    {
        private readonly IImportStrategyFactory<IImportResult> importStrategyFactory;
        private readonly IFilesService filesService;
        private readonly INotificationService notificationService;

        public ImportService(IImportStrategyFactory<IImportResult> importStrategyFactory, IFilesService filesService, INotificationService notificationService)
        {
            this.importStrategyFactory = importStrategyFactory;
            this.filesService = filesService;
            this.notificationService = notificationService;
        }

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

        public async Task<BaseResponse<IImportResult>> ImportExcelFile(
            Guid fileId,
            PlatformEnum platform,
            IEnumerable<FieldMapping> mappings,
            CancellationToken cancellationToken)
        {
            var strategy = importStrategyFactory.CreateStrategy(platform);

            var result = await strategy.Import(fileId, mappings, cancellationToken);

            await notificationService.SendNotificationAsync(NotificationType.Object,null, result);

            // TODO тут по итогу должна валидироваться и сохраняться инфа по тем моделям импорта, что мы получили
            return new BaseResponse<IImportResult>()
            {
                IsSuccess = true,
                Data = result
            };
        }
    }
}
