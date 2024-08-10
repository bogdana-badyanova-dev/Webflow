using Webflow.API.Dto.Import;
using Webflow.Application.Interfaces;
using Webflow.Application.Interfaces.Import;

namespace Webflow.Application.Helpers
{
    public partial class MoodleImportStrategy : BaseImportStrategy<IImportResult, MoodleImport>
    {
        public override async Task<IImportResult> Import(Guid fileId, IEnumerable<FieldMapping> mappings, CancellationToken cancellationToken)
        {
            var file = await filesService.DownloadFile(fileId, cancellationToken);

            var response = new MoodleImportResult
            {
                FileId = fileId
            };

            var data = ConvertFileContentToModelCollection(file.Data.Content, mappings);

            response.Data = data;
            return response;
        }
    }
}
