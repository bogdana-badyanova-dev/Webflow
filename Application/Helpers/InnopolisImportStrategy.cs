using Webflow.Application.Interfaces.Import;
using Webflow.Application.Interfaces;
using Webflow.API.Dto.Import;
using Webflow.Application.Services.FilesService.Interfaces;
using OfficeOpenXml;

namespace Webflow.Application.Helpers
{
    // TODO Вынести 
    public class InnopolisImportResult : ImportResult
    {
        public IEnumerable<InnopolisImport> Data { get; set; }
    }

    public class InnopolisImportStrategy : BaseImportStrategy<ImportResult, InnopolisImport>
    {
        private readonly IFilesService filesService;

        public InnopolisImportStrategy(IFilesService filesService)
        {
            this.filesService = filesService;
        }

        public override async Task<ImportResult> Import(Guid fileId, IEnumerable<FieldMapping> mappings, CancellationToken cancellationToken)
        {
            var file = await filesService.DownloadFile(fileId, cancellationToken);
            var response = new InnopolisImportResult
            {
                FileId = fileId
            };

            var data = ConvertFileContentToModelCollection(file.Data.Content, mappings);

            response.Data = data;
            return response;
        }
    }
}
