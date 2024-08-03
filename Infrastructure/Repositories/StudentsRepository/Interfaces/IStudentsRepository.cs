using Webflow.API.Dto.Students;
using Webflow.Domain.Shared;
using Webflow.Domain.Students;
using Webflow.Infrastructure.Repositories.BaseRepository.Interfaces;

namespace Webflow.Infrastructure.Repositories.StudentsRepository.Interfaces
{
    /// <summary>
    /// Интерфейс для репозитория студентов, наследующий базовый репозиторий
    /// </summary>
    public interface IStudentsRepository :IBaseRepository<Student>
    {
        /// <summary>
        /// Получение студентов с поддержкой пагинации, фильтрации и сортировки
        /// </summary>
        /// <param name="request">Запрос с параметрами для фильтрации, пагинации и сортировки</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Пагинированный список студентов</returns>
        Task<PaginatedResponse<Student>> GetPagedAsync(GetPagedStudentsRequest request, CancellationToken cancellationToken);
    }
}
