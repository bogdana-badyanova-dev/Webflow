using Webflow.Application.Enums;
using Webflow.Domain.Skills;
using Webflow.Domain.Students;

namespace Webflow.Application.Interfaces
{
    /// <summary>
    /// Интерфейс для курса
    /// </summary>
    public interface ICourse: IMutableEntity<Guid>
    {
        /// <summary>
        /// Название курса
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Платформа, на которой предлагается курс
        /// </summary>
        PlatformEnum Platform { get; set; }

        /// <summary>
        /// Навыки, связанные с курсом
        /// </summary>
        ICollection<Skill> Skills { get; set; }

        /// <summary>
        /// Студенты, записанные на курс
        /// </summary>
        ICollection<Student> Students { get; set; }
    }

}
