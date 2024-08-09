using Webflow.API.Dto.Import;

namespace Webflow.Application.Interfaces.Import
{
    public abstract class BaseImportResult: IImportResult
    {
        public Guid FileId { get; set; }
        public IEnumerable<InnopolisImport> Data { get; set; }
    }
}
