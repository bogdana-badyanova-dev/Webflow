namespace Webflow.Domain.Shared
{
    /// <summary>
    /// Базовый класс для всех сущностей
    /// </summary>
    public abstract class BaseEntity<TId>
    {
        /// <summary>
        /// Уникальный идентификатор сущности
        /// </summary>
        public TId Id { get; set; }

        /// <summary>
        /// Дата создания сущности
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
