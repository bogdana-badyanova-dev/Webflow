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
        public required string FieldName { get; set; }

        /// <summary>
        /// Направление сортировк
        /// </summary>
        public required SortDirectionEnum Direction { get; set; }
    }

}
