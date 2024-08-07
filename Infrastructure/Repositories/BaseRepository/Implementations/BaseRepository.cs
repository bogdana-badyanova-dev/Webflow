using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Webflow.Domain.Shared;
using Webflow.Infrastructure.Repositories.BaseRepository.Interfaces;

namespace Webflow.Infrastructure.Repositories.BaseRepository.Implementations
{
    /// <summary>
    /// Базовый репозиторий для работы с сущностями в контексте данных
    /// </summary>
    /// <typeparam name="T">Тип сущности, с которой работает репозиторий. Должен быть классом</typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity<Guid>
    {
        /// <summary>
        /// Контекст данных, используемый для взаимодействия с базой данных
        /// </summary>
        protected readonly WebflowContext _context;
        protected readonly DbSet<T> _dbSet;

        /// <summary>
        /// Конструктор класса <see cref="BaseRepository{T}"/>.
        /// </summary>
        /// <param name="context">Контекст данных, используемый для работы с базой данных</param>
        public BaseRepository(WebflowContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        /// <summary>
        /// Получает сущность по уникальному идентификатору
        /// </summary>
        /// <param name="id">Уникальный идентификатор сущности</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Сущность с указанным идентификатором или null, если не найдена</returns>
        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        /// <summary>
        /// Получает все сущности из репозитория
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Коллекция всех сущностей</returns>
        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Выполняет поиск сущностей по заданному условию
        /// </summary>
        /// <param name="predicate">Условие для фильтрации сущностей</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Коллекция сущностей, удовлетворяющих условию</returns>
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _dbSet.Where(predicate).ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Добавляет новую сущность в репозиторий
        /// </summary>
        /// <param name="entity">Добавляемая сущность</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>True, если сущность успешно добавлена, иначе false</returns>
        public async Task<Guid> AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        /// <summary>
        /// Добавляет несколько сущностей в репозиторий
        /// </summary>
        /// <param name="entities">Коллекция добавляемых сущностей</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Коллекция добавленных сущностей</returns>
        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            await _dbSet.AddRangeAsync(entities, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entities;
        }

        /// <summary>
        /// Обновляет существующую сущность в репозитории
        /// </summary>
        /// <param name="entity">Обновляемая сущность</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Обновленная сущность</returns>
        public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        /// <summary>
        /// Удаляет сущность из репозитория
        /// </summary>
        /// <param name="entity">Удаляемая сущность</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>True, если сущность успешно удалена, иначе false</returns>
        public async Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            if (entity == null) return false;

            var result = _dbSet.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return result.State == EntityState.Modified || result.State == EntityState.Deleted;
        }

        /// <summary>
        /// Удаляет несколько сущностей из репозитория
        /// </summary>
        /// <param name="entities">Коллекция удаляемых сущностей</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>True, если все сущности успешно удалены, иначе false</returns>
        public async Task<bool> DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            if (!entities.Any()) return false;

            _dbSet.RemoveRange(entities);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return entities.All(e => _context.Entry(e).State == EntityState.Modified || _context.Entry(e).State == EntityState.Deleted);
        }
    }
}