using Webflow.API.Dto.Import;

namespace Webflow.Application.Interfaces.Import
{
    public interface IImportStrategy<T> where T : ImportResult
    {
        public Task<T> Import(Guid fileId, IEnumerable<FieldMapping> mappings, CancellationToken cancellationToken);
    }
}
