using Webflow.Domain.Shared;

namespace Webflow.Domain.Files
{
    /// <summary>
    /// Представляет загруженный файл, связанный с сущностью в базе данных.
    /// </summary>
    public class UploadedFile : BaseEntity<Guid>
    {
        /// <summary>
        /// Идентификатор файла в хранилище.
        /// </summary>
        public required string FileId { get; set; }

        /// <summary>
        /// Указывает, был ли файл обработан.
        /// Значение по умолчанию - false.
        /// </summary>
        public bool IsProcessed { get; set; } = false;
    }
}
