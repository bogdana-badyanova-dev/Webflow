using Webflow.Application.Enums;

namespace Webflow.Application.Interfaces.Courses
{
    /// <summary>
    /// Интерфейс для курса в Иннополисе
    /// </summary>
    public interface IInnopolisCourse : ICourse
    {
        /// <summary>
        /// Количество этапов оценки курса
        /// </summary>
        public int AssessmentStagesCount { get; set; }

        /// <summary>
        /// Планируемый уровень навыков, который должен быть достигнут по окончании курса
        /// </summary>
        public SkillLevelEnum PlannedSkillLevel { get; set; }
    }
}
