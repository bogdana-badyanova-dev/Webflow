using Webflow.Domain.Shared;

namespace Webflow.Domain.Institutes
{
    /// <summary>
    /// Класс, представляющий институт
    /// </summary>
    public class Institute : BaseEntity<Guid>
    {
        /// <summary>
        /// Название института
        /// </summary>
        public required string Name { get; set; }
    }

}
