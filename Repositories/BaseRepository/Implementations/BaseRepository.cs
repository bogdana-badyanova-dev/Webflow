using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Webflow.Data;
using Webflow.Repositories.BaseRepository.Interfaces;

namespace Webflow.Repositories.BaseRepository.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly WebflowContext _context;

        public BaseRepository(WebflowContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<bool> AddAsync(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.State == EntityState.Added;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return entities;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            if (entity == null) return false;

            var result = _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return result.State == EntityState.Modified || result.State == EntityState.Deleted;
        }

        public async Task<bool> DeleteRangeAsync(IEnumerable<T> entities)
        {
            if (!entities.Any()) return false;

            _context.Set<T>().RemoveRange(entities);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return entities.All(e => _context.Entry(e).State == EntityState.Modified || _context.Entry(e).State == EntityState.Deleted);
        }
    }
}