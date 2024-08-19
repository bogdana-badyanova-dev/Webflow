using Webflow.Domain.Shared;

namespace Webflow.Domain.Skills
{
    /// <summary>
    /// Представляет сущность компетенции.
    /// </summary>
    public class Skill : MutableEntity<Guid>
    {
        /// <summary>
        /// Наименование компетенции.
        /// </summary>
        public string Name { get; set; }
    }
}
