using Webflow.Domain.Students;
using Webflow.Infrastructure.Repositories.BaseRepository.Interfaces;

namespace Webflow.Infrastructure.Repositories.StudentsRepository.Interfaces
{
    /// <summary>
    /// Интерфейс для репозитория студентов, наследующий базовый репозиторий
    /// </summary>
    public interface IStudentsRepository :IBaseRepository<Student>
    {
    }
}
