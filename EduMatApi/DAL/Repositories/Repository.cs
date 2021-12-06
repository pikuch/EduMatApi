using Microsoft.EntityFrameworkCore;

namespace EduMatApi.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly EduMatApiDbContext _dbContext;

        public Repository(EduMatApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity?> AddAsync(TEntity item)
        {
            await _dbContext.Set<TEntity>().AddAsync(item);
            return (_dbContext.SaveChanges() > 0) ? item : null;
        }

        public async Task<bool> UpdateAsync(TEntity item)
        {
            return await _dbContext.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var toRemove = await _dbContext.Set<TEntity>().FindAsync(id);
            if (toRemove != null)
            {
                _dbContext.Set<TEntity>().Remove(toRemove);
                return await _dbContext.SaveChangesAsync() == 1;
            }
            else
            {
                return false;
            }
        }
    }
}
