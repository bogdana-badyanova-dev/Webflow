using Webflow.Application.Enums;

namespace Webflow.API.Dto.Import
{
    public class InnopolisImport : BaseImportDto
    {
        public string InnopolisAccountId { get; set; }
        public string Snils { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ActivityStatusEnum ActivityStatus { get; set; }
        public int AssessmentStage { get; set; }
        public AssessmentStatusEnum AssessmentStatus { get; set; }
        public DateTime AssessmentCompleteDate { get; set; }
        public int AttemptCount { get; set; }
        public int TryTime { get; set; }
        public string SkillName { get; set; }
        public SkillLevelEnum PlannedSkillLevel { get; set; }
        public SkillLevelEnum FinalSkillLevel { get; set; }
        public ProficiencyLevelEnum ProficiencyLevel { get; set; }
        public double FinalScores { get; set; }
    }
}
