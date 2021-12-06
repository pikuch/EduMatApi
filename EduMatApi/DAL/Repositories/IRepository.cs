
namespace EduMatApi.DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> AddAsync(TEntity item);
        Task<bool> DeleteAsync(int id);
        Task<ICollection<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(TEntity item);
    }
}