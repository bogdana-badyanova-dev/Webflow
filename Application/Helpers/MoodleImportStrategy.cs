using Webflow.API.Dto.Import;
using Webflow.Application.Interfaces;

namespace Webflow.Application.Helpers
{
    public class MoodleImportStrategy : BaseImportStrategy<ImportResult, MoodleImport>
    {
        public override async Task<ImportResult> Import(Guid fileId, IEnumerable<FieldMapping> mappings, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Тут надо разруливать импорта из мудла");
        }
    }
}
