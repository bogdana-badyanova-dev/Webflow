using Webflow.Application.Interfaces;

namespace Webflow.Domain.CourseResults
{
    /// <summary>
    /// Класс, представляющий результаты курса, предлагаемого АНО "Университет Иннополис"
    /// </summary>
    public class InnopolisCourseResult : BaseCourseResult, IInnopolisCourseResult, IMutableEntity<Guid>
    {
    }
}
