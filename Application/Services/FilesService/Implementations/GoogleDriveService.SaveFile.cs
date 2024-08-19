using Webflow.Application.Services.FilesService.Interfaces;
using Webflow.Domain.Files;

namespace Webflow.Application.Services.FilesService.Implementations
{
    public partial class GoogleDriveService : IFilesService
    {
        /// <summary>
        /// Сохраняет файл по указанному идентификатору и возвращает его идентификатор.
        /// </summary>
        /// <param name="fileId">Идентификатор файла для сохранения.</param>
        /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
        /// <returns>Идентификатор сохраненного файла.</returns>
        private async Task<Guid> SaveFile(string fileId, CancellationToken cancellationToken)
        {
            var importedFile = new UploadedFile
            {
                Id = new Guid(),
                FileId = fileId,
            };

            return await filesRepository.AddAsync(importedFile, cancellationToken);
        }
    }
}