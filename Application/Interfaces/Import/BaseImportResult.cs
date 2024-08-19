using Webflow.API.Dto.Import;

namespace Webflow.Application.Interfaces.Import
{
    /// <summary>
    /// Базовый класс для результата импорта данных, содержащий идентификатор файла и данные
    /// </summary>
    /// <typeparam name="T">Тип данных, производный от <see cref="BaseImportDto"/></typeparam>
    public abstract class BaseImportResult<T> : IImportResult where T : BaseImportDto
    {
        /// <summary>
        /// Идентификатор файла, связанного с результатом импорта
        /// </summary>
        public Guid FileId { get; set; }

        /// <summary>
        /// Список данных, импортированных из файла
        /// </summary>
        public IEnumerable<T> Data { get; set; }
    }
}
