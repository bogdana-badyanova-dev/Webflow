namespace Webflow.API.Dto.Import
{
    public class MoodleImport : BaseImportDto
    {
        public string MoodleAccountId { get; set; }
        public IEnumerable<string> IsComplete { get; set; } = new List<string>();
        public IEnumerable<string> CompleteDate { get; set; } = new List<string>();
    }
}
