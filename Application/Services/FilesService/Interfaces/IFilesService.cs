using Webflow.API.Dto.Import;
using Webflow.API.Dto.Shared;

namespace Webflow.Application.Services.FilesService.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с файлами, предоставляющий методы для загрузки, скачивания и удаления файлов.
    /// </summary>
    public interface IFilesService
    {
        /// <summary>
        /// Загружает файл на сервер.
        /// </summary>
        /// <param name="file">Файл для загрузки.</param>
        /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
        /// <returns>Ответ, содержащий идентификатор загруженного файла.</returns>
        public Task<BaseResponse<Guid>> UploadFile(IFormFile file, CancellationToken cancellationToken);

        /// <summary>
        /// Скачивает файл по его идентификатору.
        /// </summary>
        /// <param name="fileId">Идентификатор файла для скачивания.</param>
        /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
        /// <returns>Ответ, содержащий информацию о файле.</returns>
        public Task<BaseResponse<FileResult>> DownloadFile(Guid fileId, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет файл по его идентификатору.
        /// </summary>
        /// <param name="fileId">Идентификатор файла для удаления.</param>
        /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
        /// <returns>Ответ, указывающий на успешность операции удаления.</returns>
        public Task<BaseResponse<bool>> DeleteFile(Guid fileId, CancellationToken cancellationToken);
    }
}
