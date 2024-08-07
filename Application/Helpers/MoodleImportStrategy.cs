using Webflow.API.Dto.Import;
using Webflow.Application.Interfaces;
using Webflow.Application.Interfaces.Import;

namespace Webflow.Application.Helpers
{
    public class MoodleImportStrategy : IImportStrategy<ImportResult>
    {
        public Task<ImportResult> Import(Guid fileId, IEnumerable<FieldMapping> mappings, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Тут надо разруливать импорта из мудла");
        }
    }
}
