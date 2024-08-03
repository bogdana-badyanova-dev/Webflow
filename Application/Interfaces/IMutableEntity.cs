using Webflow.Domain.Shared;

namespace Webflow.Application.Interfaces
{
    /// <summary>
    /// Интерфейс для сущностей, которые могут изменяться.
    /// </summary>
    public interface IMutableEntity<T>: IBaseEntity<T>
    {
        /// <summary>
        /// Дата обновления сущности, по умолчанию - null
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Дата удаления сущности, по умолчанию - null
        /// </summary>
        public DateTime? RemovedAt { get; set; }
    }
}
