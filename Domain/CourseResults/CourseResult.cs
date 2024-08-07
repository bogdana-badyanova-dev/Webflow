using Webflow.Application.Interfaces.CourseResults;

namespace Webflow.Domain.CourseResults
{
    /// <summary>
    /// Представляет результат курса, который может быть как Moodle-результатом, так и результатом Иннополиса
    /// </summary>
    /// <remarks>
    /// Класс <see cref="CourseResult"/> наследует от <see cref="MoodleCourseResult"/> и реализует интерфейс <see cref="IInnopolisCourseResult"/>
    /// В зависимости от платформы, данный результат может содержать специфические свойства:
    /// <list type="bullet">
    ///     <item><description>Специфичные свойства для Moodle, унаследованные от <see cref="MoodleCourseResult"/></description></item>
    ///     <item><description>Специфичные свойства для Иннополиса, определенные в <see cref="IInnopolisCourseResult"/></description></item>
    /// </list>
    /// </remarks>
    public class CourseResult : MoodleCourseResult, IInnopolisCourseResult
    {
    }
}
