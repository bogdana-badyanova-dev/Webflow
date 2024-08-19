using Webflow.Application.Interfaces;
using Webflow.API.Dto.Import;
using Webflow.Application.Interfaces.Import;

namespace Webflow.Application.Helpers
{
    public partial class InnopolisImportStrategy : BaseImportStrategy<IImportResult, InnopolisImport>
    {
        public override async Task<IImportResult> Import(Guid fileId, IEnumerable<FieldMapping> mappings, CancellationToken cancellationToken = default)
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
