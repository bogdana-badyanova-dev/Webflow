using Webflow.Application.Interfaces.Import;
using Webflow.Application.Interfaces;
using Webflow.API.Dto.Import;

namespace Webflow.Application.Helpers
{
    public class InnopolisImportStrategy : IImportStrategy<ImportResult>
    {
        public Task<ImportResult> Import(Guid fileId, IEnumerable<FieldMapping> mappings, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Тут надо разруливать импорта из иннополиса");
        }
    }
}
