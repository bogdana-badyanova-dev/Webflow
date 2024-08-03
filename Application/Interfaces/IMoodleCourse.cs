using Webflow.Domain.Cources;

namespace Webflow.Application.Interfaces
{
    /// <summary>
    /// Интерфейс для курса в СДО СевГУ
    /// </summary>
    public interface IMoodleCourse: ICourse
    {
        /// <summary>
        /// Элементы курса в СДО СевГУ
        /// </summary>
        IEnumerable<MoodleCourseElement> CourseElements { get; set; }
    }
}
