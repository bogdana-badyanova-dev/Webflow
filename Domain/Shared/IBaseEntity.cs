namespace Webflow.Domain.Shared
{
    /// <summary>
    /// Интерфейс для базовой сущности с уникальным идентификатором и датой создания.
    /// </summary>
    /// <typeparam name="TId">Тип уникального идентификатора</typeparam>
    public interface IBaseEntity<TId>
    {
        /// <summary>
        /// Уникальный идентификатор сущности
        /// </summary>
        TId Id { get; set; }

        /// <summary>
        /// Дата создания сущности
        /// </summary>
        DateTime CreatedAt { get; set; }
    }
}
