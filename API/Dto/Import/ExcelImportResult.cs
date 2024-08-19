using Webflow.Application.Interfaces;

namespace Webflow.API.Dto.Import
{
    /// <summary>
    /// Результат импорта Excel-файла, содержащий идентификатор файла, заголовки и предварительный просмотр строк.
    /// </summary>
    public class ExcelImportResult : IImportResult
    {
        /// <summary>
        /// Идентификатор файла, из которого был выполнен импорт
        /// </summary>
        public Guid FileId { get; set; }

        /// <summary>
        /// Список заголовков столбцов в импортированном файле
        /// </summary>
        public IEnumerable<string> Headers { get; set; }

        /// <summary>
        /// Список строк предварительного просмотра данных из импортированного файла.
        /// Каждая строка представлена в виде словаря, где ключи — это имена столбцов, а значения — данные в соответствующих ячейках
        /// </summary>
        public IEnumerable<IDictionary<string, object>> PreviewRows { get; set; }
    }

}
