using Webflow.Application.Enums;
using Webflow.Application.Interfaces;
using Webflow.Domain.Cources;

namespace Webflow.Application.Helpers
{
    /// <summary>
    /// Фабрика для создания объектов курса на основе предоставленного интерфейса <see cref="ICourse"/>.
    /// </summary>
    /// <remarks>
    /// В зависимости от платформы, указанной в объекте <see cref="ICourse"/>, создается экземпляр конкретного типа курса:
    /// <list type="bullet">
    ///     <item><description><see cref="InnopolisCourse"/> для платформы <see cref="PlatformEnum.INNOPOLIS"/></description></item>
    ///     <item><description><see cref="MoodleCourse"/> для платформы <see cref="PlatformEnum.MOODLE"/></description></item>
    /// </list>
    /// </remarks>
    public class CourseFactory : IFactory<ICourse>
    {
        /// <summary>
        /// Создает объект курса в зависимости от платформы, указанной в объекте ICourse.
        /// </summary>
        /// <param name="course">Объект курса с данными</param>
        /// <returns>Объект конкретного типа курса</returns>
        public ICourse Create(ICourse course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course), "Курс не может быть null");
            }

            return course switch
            {
                { Platform: PlatformEnum.INNOPOLIS } when course is IInnopolisCourse innopolisCourse =>
                    new InnopolisCourse
                    {
                        Id = course.Id,
                        CreatedAt = course.CreatedAt,
                        Name = course.Name,
                        Platform = course.Platform,
                        Skills = course.Skills,
                        Students = course.Students,
                        AssessmentStagesCount = innopolisCourse.AssessmentStagesCount,
                        PlannedSkillLevel = innopolisCourse.PlannedSkillLevel
                    },

                { Platform: PlatformEnum.MOODLE } when course is IMoodleCourse moodleCourse =>
                    new MoodleCourse
                    {
                        Id = course.Id,
                        CreatedAt = course.CreatedAt,
                        Name = course.Name,
                        Platform = course.Platform,
                        Skills = course.Skills,
                        Students = course.Students,
                        CourseElements = moodleCourse.CourseElements
                    },

                _ => throw new NotSupportedException($"Платформа {course.Platform} не поддерживается")
            };
        }
    }
}
