using Microsoft.EntityFrameworkCore;
using WebSystem.Mvc.Core.Interfaces;

namespace WebSystem.Mvc.Infrastructure.Data.Repositories
{
    public abstract class BaseRepositoy<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _appContext;
        protected readonly DbSet<T> _dbSet;
        public BaseRepositoy(AppDbContext appContext)
        {
            _appContext = appContext;
            _dbSet = _appContext.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task SaveAsync(T entity)
        {
            _dbSet.Add(entity);
            await SaveChangeAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await SaveChangeAsync();
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            _dbSet.Remove(_dbSet.Find(id));
            await SaveChangeAsync();
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _appContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _appContext?.Dispose();
        }
    }
}
