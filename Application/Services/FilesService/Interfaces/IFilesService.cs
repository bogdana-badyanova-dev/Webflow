using Webflow.API.Dto.Shared;

namespace Webflow.Application.Services.FilesService.Interfaces
{
    /// <summary>
    /// Интерфейс для сервиса работы с файлами
    /// </summary>
    public interface IFilesService
    {
        /// <summary>
        /// Загружает файл в хранилище
        /// </summary>
        /// <param name="file">Файл для загрузки</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Ответ с идентификатором загруженного файла</returns>
        public Task<BaseResponse<string>> UploadFile(IFormFile file, CancellationToken cancellationToken);
        public Task<bool> DeleteFile(Guid id, CancellationToken cancellationToken);
        public Task<Domain.Files.File> GetFileById(Guid id, CancellationToken cancellationToken);
    }
}
