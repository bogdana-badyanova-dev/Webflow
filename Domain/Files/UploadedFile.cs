using Webflow.Domain.Shared;

namespace Webflow.Domain.Files
{
    public class UploadedFile : BaseEntity<Guid>
    {
        public required string FileId { get; set; }
        public bool IsProcessed { get; set; } = false;
    }
}
