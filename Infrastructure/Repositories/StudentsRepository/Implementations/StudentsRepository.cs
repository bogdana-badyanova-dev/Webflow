using Webflow.Domain.Students;
using Webflow.Infrastructure.Repositories.BaseRepository.Implementations;
using Webflow.Infrastructure.Repositories.StudentsRepository.Interfaces;

namespace Webflow.Infrastructure.Repositories.StudentsRepository.Implementations
{
    /// <summary>
    /// Репозиторий для работы с сущностями студентов
    /// </summary>
    public class StudentsRepository : BaseRepository<Student>, IStudentsRepository
    {
        /// <summary>
        /// Конструктор класса репозитория студентов
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public StudentsRepository(WebflowContext context) : base(context)
        {
        }
    }
}
