using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto.Import;
using Webflow.API.Dto.Shared;
using Webflow.Application.Enums;
using Webflow.Application.Interfaces;

namespace Webflow.Application.Services.Import.Interfaces
{
    public interface IImportService
    {
        public Task<BaseResponse<ExcelImportResult>> ImportPreviewExcelFile(IFormFile file, CancellationToken cancellationToken, int previewRowsCount = 5);
        public Task<BaseResponse<IImportResult>> ImportExcelFile(Guid fileId, PlatformEnum platform, IEnumerable<FieldMapping> mappings, CancellationToken cancellationToken);
    }
}
