using Webflow.Application.Enums;

namespace Webflow.Application.Interfaces
{
    /// <summary>
    /// Интерфейс, представляющий поле для сортировки
    /// </summary>
    public interface ISortField
    {
        /// <summary>
        /// Наименование поля, по которому выполняется сортировка
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// Направление сортировки
        /// </summary>
        public SortDirectionEnum Direction { get; set; }
    }
}
