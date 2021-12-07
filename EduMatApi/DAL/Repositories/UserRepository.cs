using EduMatApi.Models.Authentification;
using Microsoft.EntityFrameworkCore;

namespace EduMatApi.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _dbContext;

        public UserRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            return (_dbContext.SaveChanges() == 1) ? user : null;
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            return await _dbContext.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User?> GetByLoginAsync(string login)
        {
            return await _dbContext.Users.FindAsync(login);
        }
    }
}
