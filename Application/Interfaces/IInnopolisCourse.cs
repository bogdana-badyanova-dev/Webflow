using Webflow.Application.Enums;

namespace Webflow.Application.Interfaces
{
    /// <summary>
    /// Интерфейс для курса в Иннополисе
    /// </summary>
    public interface IInnopolisCourse: ICourse
    {
        /// <summary>
        /// Количество этапов оценки курса
        /// </summary>
        int AssessmentStagesCount { get; set; }

        /// <summary>
        /// Планируемый уровень навыков, который должен быть достигнут по окончании курса
        /// </summary>
        SkillLevelEnum PlannedSkillLevel { get; set; }
    }
}
