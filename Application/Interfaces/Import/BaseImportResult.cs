using Webflow.API.Dto.Import;

namespace Webflow.Application.Interfaces.Import
{
    public abstract class BaseImportResult <K>: IImportResult
         where K : class, new()
    {
        public Guid FileId { get; set; }
        public IEnumerable<K> Data { get; set; }
    }
}
