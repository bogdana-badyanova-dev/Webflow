using Webflow.Domain.Shared;

namespace Webflow.API.Dto.Institutes
{
    /// <summary>
    /// Объект передачи данных института
    /// </summary>
    public class InstituteView : BaseEntity<Guid>
    {
        /// <summary>
        /// Название института
        /// </summary>
        public required string Name { get; set; }
    }
}
