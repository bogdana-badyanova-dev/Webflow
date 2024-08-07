﻿using Webflow.Application.Enums;
using Webflow.Application.Interfaces;

namespace Webflow.Domain.Cources
{
    /// <summary>
    /// Класс, представляющий курс, предлагаемый АНО "Университет Иннополис"
    /// </summary>
    public class InnopolisCourse : BaseCourse, IInnopolisCourse
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
