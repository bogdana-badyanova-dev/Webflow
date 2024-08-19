using Webflow.Application.Enums;

namespace Webflow.API.Dto.Import
{
    /// <summary>
    /// Класс, представляющий данные для предоставления операции импорта.
    /// </summary>
    public class ImportProvideData
    {
        /// <summary>
        /// Уникальный идентификатор файла.
        /// </summary>
        public Guid FileId { get; set; }

        /// <summary>
        /// Платформа, на которую осуществляется импорт.
        /// </summary>
        public PlatformEnum Platform { get; set; }

        /// <summary>
        /// Коллекция отображений полей для импорта данных.
        /// </summary>
        public IEnumerable<FieldMapping> Mappings { get; set; }
    }
}
