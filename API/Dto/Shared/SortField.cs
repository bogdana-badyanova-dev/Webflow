using Webflow.Application.Enums;

namespace Webflow.Domain.Shared
{
    /// <summary>
    /// Абстрактный класс, представляющий поле для сортировки
    /// </summary>
    public abstract class SortField
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
