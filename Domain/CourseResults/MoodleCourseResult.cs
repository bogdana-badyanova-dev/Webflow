using Webflow.Application.Interfaces;

namespace Webflow.Domain.CourseResults
{
    /// <summary>
    /// Класс, представляющий результаты курса, предлагаемого СДО СевГУ
    /// </summary>
    public class MoodleCourseResult : BaseCourseResult, IMoodleCourseResult, IMutableEntity<Guid>
    {
    }
}
