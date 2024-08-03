using Webflow.Application.Enums;
using Webflow.Application.Interfaces;
using Webflow.Domain.Shared;
using Webflow.Domain.Skills;
using Webflow.Domain.Students;

namespace Webflow.Domain.Cources
{
    /// <summary>
    /// Абстрактный базовый класс для курсов
    /// </summary>
    public abstract class BaseCourse : MutableEntity<Guid>, ICourse
    {
        /// <summary>
        /// Название курса
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Платформа, на которой предлагается курс
        /// </summary>
        public required PlatformEnum Platform { get; set; } = PlatformEnum.UNDEFINED;

        /// <summary>
        /// Навыки, связанные с курсом
        /// </summary>
        public virtual ICollection<Skill>? Skills { get; set; } = new List<Skill>();

        /// <summary>
        /// Студенты, записанные на курс
        /// </summary>
        public virtual ICollection<Student>? Students { get; set; } = new List<Student>();
    }
}
