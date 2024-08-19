using Webflow.Application.Services.FilesService.Interfaces;
using Webflow.Infrastructure.Repositories.FilesRepository.Interfaces;

namespace Webflow.Application.Services.FilesService.Implementations
{
    /// <summary>
    /// Сервис для работы с файлами в Google Drive
    /// </summary>
    public partial class GoogleDriveService : IFilesService
    {
        private readonly IConfiguration configuration;
        private readonly IFilesRepository filesRepository;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="GoogleDriveService"/>.
        /// </summary>
        /// <param name="configuration">Объект конфигурации, используемый для доступа к настройкам.</param>
        /// <param name="filesRepository">Репозиторий для работы с файлами, используемый для хранения и извлечения файлов.</param>
        public GoogleDriveService(IConfiguration configuration, IFilesRepository filesRepository)
        {
            this.configuration = configuration;
            this.filesRepository = filesRepository;
        }
    }
}