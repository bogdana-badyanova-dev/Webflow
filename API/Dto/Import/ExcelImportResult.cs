using Webflow.Application.Interfaces;

namespace Webflow.API.Dto.Import
{
    public class ExcelImportResult : IImportResult
    {
        public Guid FileId { get; set; }
        public IEnumerable<string> Headers { get; set; }
        public IEnumerable<IDictionary<string, object>> PreviewRows { get; set; }
    }
}
