using Webflow.API.Dto.Import;

namespace Webflow.Application.Interfaces.Import
{
    public abstract class BaseImportResult<T>: IImportResult where T: BaseImportDto
    {
        public Guid FileId { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
