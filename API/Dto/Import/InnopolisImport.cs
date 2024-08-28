using Webflow.Application.Enums;

namespace Webflow.API.Dto.Import
{
    /// <summary>
    /// Представляет импорт данных для студентов Иннополиса
    /// </summary>
    public class InnopolisImport : BaseImport
    {
        /// <summary>
        /// Идентификатор аккаунта в Иннополисе
        /// </summary>
        public string InnopolisAccountId { get; set; }

        /// <summary>
        /// СНИЛС студента
        /// </summary>
        public string Snils { get; set; }

        /// <summary>
        /// Дата рождения студента
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Дата регистрации студента
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Статус активности студента
        /// </summary>
        public ActivityStatusEnum ActivityStatus { get; set; }

        /// <summary>
        /// Этап оценки
        /// </summary>
        public int AssessmentStage { get; set; }

        /// <summary>
        /// Статус оценки
        /// </summary>
        public AssessmentStatusEnum AssessmentStatus { get; set; }

        /// <summary>
        /// Дата завершения оценки
        /// </summary>
        public DateTime AssessmentCompleteDate { get; set; }

        /// <summary>
        /// Количество попыток
        /// </summary>
        public int AttemptCount { get; set; }

        /// <summary>
        /// Время попытки
        /// </summary>
        public int TryTime { get; set; }

        /// <summary>
        /// Название навыка
        /// </summary>
        public string SkillName { get; set; }

        /// <summary>
        /// Планируемый уровень навыка
        /// </summary>
        public SkillLevelEnum PlannedSkillLevel { get; set; }

        /// <summary>
        /// Финальный уровень навыка
        /// </summary>
        public SkillLevelEnum FinalSkillLevel { get; set; }

        /// <summary>
        /// Уровень профпригодности
        /// </summary>
        public ProficiencyLevelEnum ProficiencyLevel { get; set; }

        /// <summary>
        /// Финальные баллы
        /// </summary>
        public double FinalScores { get; set; }
    }
}
