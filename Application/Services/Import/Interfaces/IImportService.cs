using Webflow.API.Dto.Import;
using Webflow.API.Dto.Shared;

namespace Webflow.Application.Services.Import.Interfaces
{
    public interface IImportService
    {
        public Task<BaseResponse<ExcelImportResult>> ImportPreviewExcelFile(IFormFile file, CancellationToken cancellationToken, int previewRowsCount = 5);
    }
}
