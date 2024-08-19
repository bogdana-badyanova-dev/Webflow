using Webflow.Domain.Files;
using Webflow.Infrastructure.Repositories.BaseRepository.Implementations;
using Webflow.Infrastructure.Repositories.FilesRepository.Interfaces;

namespace Webflow.Infrastructure.Repositories.FilesRepository.Implementations
{
    /// <summary>
    /// Репозиторий для работы с сущностями <see cref="UploadedFile"/>.
    /// Наследует базовые методы работы с сущностями от <see cref="BaseRepository{T}"/>.
    /// </summary>
    public class FilesRepository : BaseRepository<UploadedFile>, IFilesRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="FilesRepository"/>.
        /// </summary>
        /// <param name="context">Контекст базы данных для работы с сущностями <see cref="UploadedFile"/>.</param>
        public FilesRepository(WebflowContext context) : base(context)
        {
        }
    }
}
