using System.Linq.Expressions;
using Webflow.Domain.Shared;

namespace Webflow.Infrastructure.Repositories.BaseRepository.Interfaces
{
    /// <summary>
    /// Интерфейс для базового репозитория с основными CRUD операциями
    /// </summary>
    /// <typeparam name="T">Тип сущности, наследующийся от <see cref="BaseEntity{Guid}"/></typeparam>
    public interface IBaseRepository<T> where T : BaseEntity<Guid>
    {
        /// <summary>
        /// Получает сущность по уникальному идентификатору
        /// </summary>
        /// <param name="id">Уникальный идентификатор сущности</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Сущность с указанным идентификатором или null, если не найдена</returns>
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получает все сущности из репозитория
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Коллекция всех сущностей</returns>
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Выполняет поиск сущностей по заданному условию
        /// </summary>
        /// <param name="predicate">Условие для фильтрации сущностей</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Коллекция сущностей, удовлетворяющих условию</returns>
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новую сущность в репозиторий
        /// </summary>
        /// <param name="entity">Добавляемая сущность</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>True, если сущность успешно добавлена, иначе false</returns>
        Task<bool> AddAsync(T entity, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет несколько сущностей в репозиторий
        /// </summary>
        /// <param name="entities">Коллекция добавляемых сущностей</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Коллекция добавленных сущностей</returns>
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет существующую сущность в репозитории
        /// </summary>
        /// <param name="entity">Обновляемая сущность</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Обновленная сущность</returns>
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет сущность из репозитория
        /// </summary>
        /// <param name="entity">Удаляемая сущность</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>True, если сущность успешно удалена, иначе false</returns>
        Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет несколько сущностей из репозитория
        /// </summary>
        /// <param name="entities">Коллекция удаляемых сущностей</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>True, если все сущности успешно удалены, иначе false</returns>
        Task<bool> DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
    }
}
