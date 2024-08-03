using Webflow.Domain.Shared;
using Webflow.Domain.Students;

namespace Webflow.Domain.Groups
{
    /// <summary>
    /// Класс, представляющий группу студентов
    /// </summary>
    public class Group : MutableEntity<Guid>
    {
        /// <summary>
        /// Название группы
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Список студентов группы
        /// </summary>
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    }

}
