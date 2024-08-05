using Webflow.Application.Interfaces;
using Webflow.Domain.Shared;

namespace Webflow.Domain.CourseResults
{
    /// <summary>
    /// Абстрактный базовый класс для результатов курсов
    /// </summary>
    public abstract class BaseCourseResult : MutableEntity<Guid>, ICourseResult
    {
    }
}
