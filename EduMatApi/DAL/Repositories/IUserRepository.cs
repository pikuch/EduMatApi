
using EduMatApi.Models.Authentification;

namespace EduMatApi.DAL.Repositories
{
    public interface IUserRepository
    {
        Task<User?> AddAsync(User user);
        Task<ICollection<User>> GetAllAsync();
        Task<User?> GetByLoginAsync(string login);
    }
}