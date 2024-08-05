using Webflow.Application.Enums;
using Webflow.Domain.Skills;
using Webflow.Domain.Students;

namespace Webflow.Application.Interfaces
{
    /// <summary>
    /// Интерфейс для курса
    /// </summary>
    public interface ICourse : IMutableEntity<Guid>
    {
        /// <summary>
        /// Название курса
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Платформа, на которой предлагается курс
        /// </summary>
        public PlatformEnum Platform { get; set; }

        /// <summary>
        /// Навыки, связанные с курсом
        /// </summary>
        public ICollection<Skill> Skills { get; set; }

        /// <summary>
        /// Студенты, записанные на курс
        /// </summary>
        public ICollection<Student> Students { get; set; }
    }
}
