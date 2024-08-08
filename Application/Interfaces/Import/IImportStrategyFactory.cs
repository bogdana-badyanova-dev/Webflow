using Webflow.API.Dto.Import;
using Webflow.Application.Enums;

namespace Webflow.Application.Interfaces.Import
{
    public interface IImportStrategyFactory<T> where T: ImportResult
    {
        IImportStrategy<T> CreateStrategy(PlatformEnum source, IEnumerable<FieldMapping> mappings, CancellationToken cancellationToken);
    }
}
