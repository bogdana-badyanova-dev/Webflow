namespace Webflow.Application.Interfaces
{
    /// <summary>
    /// Интерфейс для результата импорта, содержащий идентификатор файла.
    /// </summary>
    public interface IImportResult
    {
        /// <summary>
        /// Идентификатор файла, связанного с результатом импорта.
        /// </summary>
        Guid FileId { get; set; }
    }
}
