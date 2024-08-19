using Webflow.Domain.Files;
using Webflow.Infrastructure.Repositories.BaseRepository.Interfaces;

namespace Webflow.Infrastructure.Repositories.FilesRepository.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с репозиторием загруженных файлов.
    /// Наследует базовые методы работы с сущностями от <see cref="IBaseRepository{T}"/>.
    /// </summary>
    public interface IFilesRepository : IBaseRepository<UploadedFile>
    {
    }
}
