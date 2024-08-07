using Webflow.API.Dto.Shared;
using Webflow.Application.Interfaces;

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
        public Task<BaseResponse<Guid>> UploadFile(IFormFile file, CancellationToken cancellationToken);
        public Task<BaseResponse<FileResult>> DownloadFile(Guid fileId, CancellationToken cancellationToken);
        public Task<BaseResponse<bool>> DeleteFile(Guid fileId, CancellationToken cancellationToken);
    }
}
