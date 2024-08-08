using Webflow.Application.Interfaces;
using Webflow.Application.Interfaces.Courses;

namespace Webflow.Domain.Cources
{
    /// <summary>
    /// Класс, представляющий курс, предлагаемый в СДО СевГУ
    /// </summary>
    public class MoodleCourse : BaseCourse, IMoodleCourse, IMutableEntity<Guid>
    {
        /// <summary>
        /// Элементы курса
        /// </summary>
        public IEnumerable<MoodleCourseElement> CourseElements { get; set; } = new List<MoodleCourseElement>();
    }
}
