using Webflow.Application.Enums;
using Webflow.Application.Interfaces.Courses;
using Webflow.Domain.Skills;
using Webflow.Domain.Students;

namespace Webflow.Domain.Cources
{
    /// <summary>
    /// Представляет курс, который может быть как Moodle-курсом, так и курсом Иннополиса
    /// </summary>
    /// <remarks>
    /// Класс <see cref="Course"/> реализует интерфейсы <see cref="IMoodleCourse"/>, <see cref="IInnopolisCourse"/> и <see cref="ICourse"/>
    /// В зависимости от платформы, данный курс может содержать специфические свойства:
    /// <list type="bullet">
    ///     <item><description><see cref="AssessmentStagesCount"/> и <see cref="PlannedSkillLevel"/> для курсов Иннополиса</description></item>
    ///     <item><description><see cref="CourseElements"/> для Moodle-курсов</description></item>
    /// </list>
    /// </remarks>
    public class Course : IMoodleCourse, IInnopolisCourse
    {
        /// <summary>
        /// Уникальный идентификатор курса
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название курса
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Платформа, на которой предлагается курс
        /// </summary>
        public required PlatformEnum Platform { get; set; }

        /// <summary>
        /// Навыки, связанные с курсом
        /// </summary>
        public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();

        /// <summary>
        /// Студенты, записанные на курс
        /// </summary>
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();

        /// <summary>
        /// Количество этапов оценки курса (только для курсов Иннополиса)
        /// </summary>
        public int AssessmentStagesCount { get; set; } = 0;

        /// <summary>
        /// Планируемый уровень навыков, который должен быть достигнут по окончании курса (только для курсов Иннополиса)
        /// </summary>
        public SkillLevelEnum PlannedSkillLevel { get; set; } = SkillLevelEnum.UNDEFINED;

        /// <summary>
        /// Элементы курса (только для Moodle-курсов)
        /// </summary>
        public IEnumerable<MoodleCourseElement> CourseElements { get; set; }

        /// <summary>
        /// Дата создания курса
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Дата последнего обновления курса
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Дата удаления курса
        /// </summary>
        public DateTime? RemovedAt { get; set; }
    }
}
