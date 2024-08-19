using Webflow.API.Dto.Import;

namespace Webflow.Application.Interfaces.Import
{
    /// <summary>
    /// Интерфейс для стратегии импорта данных, определяющей метод импорта данных из файла
    /// </summary>
    /// <typeparam name="T">Тип результата импорта, реализующий <see cref="IImportResult"/></typeparam>
    public interface IImportStrategy<T> where T : IImportResult
    {
        /// <summary>
        /// Выполняет импорт данных из файла
        /// </summary>
        /// <param name="fileId">Идентификатор файла, содержащего данные для импорта</param>
        /// <param name="mappings">Коллекция отображений полей для сопоставления данных</param>
        /// <param name="cancellationToken">Токен для отмены операции импорта</param>
        /// <returns>Результат импорта данных</returns>
        Task<T> Import(Guid fileId, IEnumerable<FieldMapping> mappings, CancellationToken cancellationToken = default);
    }
}
