using Webflow.Domain.Cources;

namespace Webflow.Application.Interfaces.Courses
{
    /// <summary>
    /// Интерфейс для курса в СДО СевГУ
    /// </summary>
    public interface IMoodleCourse : ICourse
    {
        /// <summary>
        /// Элементы курса в СДО СевГУ
        /// </summary>
        public IEnumerable<MoodleCourseElement> CourseElements { get; set; }
    }
}
