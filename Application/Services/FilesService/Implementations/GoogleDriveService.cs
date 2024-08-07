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

        public GoogleDriveService(IConfiguration configuration, IFilesRepository filesRepository)
        {
            this.configuration = configuration;
            this.filesRepository = filesRepository;
        }
    }
}