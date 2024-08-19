using Microsoft.AspNetCore.Mvc;
using Webflow.API.Dto.Import;
using Webflow.API.Dto.Shared;
using Webflow.Application.Enums;
using Webflow.Application.Interfaces;

namespace Webflow.Application.Services.Import.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с импортом данных из Excel файлов.
    /// </summary>
    public interface IImportService
    {
        /// <summary>
        /// Импортирует предварительный просмотр данных из Excel файла.
        /// </summary>
        /// <param name="file">Файл Excel для предварительного просмотра.</param>
        /// <param name="cancellationToken">Токен для отмены операции.</param>
        /// <param name="previewRowsCount">Количество строк для предварительного просмотра. По умолчанию 5.</param>
        /// <returns>Результат предварительного просмотра импорта, содержащий информацию о файле и заголовках.</returns>
        public Task<BaseResponse<ExcelImportResult>> ImportPreviewExcelFile(IFormFile file, CancellationToken cancellationToken, int previewRowsCount = 5);

        /// <summary>
        /// Импортирует данные из Excel файла.
        /// </summary>
        /// <param name="fileId">Идентификатор файла Excel.</param>
        /// <param name="platform">Платформа, с которой связан файл.</param>
        /// <param name="mappings">Сопоставления полей для импорта данных.</param>
        /// <param name="cancellationToken">Токен для отмены операции.</param>
        /// <returns>Результат импорта, содержащий информацию о результате операции.</returns>
        public Task<BaseResponse<IImportResult>> ImportExcelFile(Guid fileId, PlatformEnum platform, IEnumerable<FieldMapping> mappings, CancellationToken cancellationToken);
    }

}
