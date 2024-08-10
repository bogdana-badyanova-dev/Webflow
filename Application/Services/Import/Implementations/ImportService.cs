using OfficeOpenXml;
using Webflow.API.Dto.Import;
using Webflow.API.Dto.Shared;
using Webflow.Application.Services.FilesService.Interfaces;
using Webflow.Application.Services.Import.Interfaces;

namespace Webflow.Application.Services.Import.Implementations
{
    public class ImportService : IImportService
    {
        private readonly IFilesService filesService;

        public ImportService(IFilesService filesService)
        {
            this.filesService = filesService;
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
    }
}
