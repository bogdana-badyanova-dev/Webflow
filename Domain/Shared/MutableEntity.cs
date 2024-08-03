namespace Webflow.Domain.Shared
{
    /// <summary>
    /// Базовый класс для изменяемых сущностей
    /// </summary>
    public abstract class MutableEntity<TId> : BaseEntity<TId>
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
