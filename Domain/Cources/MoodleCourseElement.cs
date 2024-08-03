using Webflow.Domain.Shared;

namespace Webflow.Domain.Cources
{
    /// <summary>
    /// Класс, представляющий элемент курса в СДО СевГУ
    /// </summary>
    public class MoodleCourseElement: MutableEntity<Guid>
    {
        /// <summary>
        /// Название элемента курса
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Дата и время крайнего срока для выполнения элемента курса
        /// </summary>
        public DateTime? Deadline { get; set; }
    }
}
