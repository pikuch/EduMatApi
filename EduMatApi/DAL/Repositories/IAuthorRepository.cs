
using EduMatApi.Models.Entities;

namespace EduMatApi.DAL.Repositories
{
    public interface IAuthorRepository
    {
        Task<Author?> AddAsync(Author author);
        Task<bool> DeleteAsync(int id);
        Task<ICollection<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(Author author);
    }
}