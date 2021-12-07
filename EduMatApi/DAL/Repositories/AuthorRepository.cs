using EduMatApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduMatApi.DAL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly EduMatApiDbContext _dbContext;

        public AuthorRepository(EduMatApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ICollection<Author>> GetAllAsync()
        {
            var authors = await _dbContext.Authors.Include(a => a.Materials).AsNoTracking().ToListAsync();
            foreach (var author in authors)
            {
                author.MaterialCounter = author.Materials?.Count ?? 0;
            }
            return authors;
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            var author = await _dbContext.Authors.FindAsync(id);
            if (author != null)
            {
                author.MaterialCounter = _dbContext.Materials.Where(m => m.AuthorId == author.Id).Count();
            }
            return author;
        }

        public async Task<Author?> AddAsync(Author author)
        {
            await _dbContext.Authors.AddAsync(author);
            return (_dbContext.SaveChanges() > 0) ? author : null;
        }

        public async Task<bool> UpdateAsync(Author author)
        {
            return await _dbContext.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var toRemove = await _dbContext.Authors.FindAsync(id);
            if (toRemove != null)
            {
                _dbContext.Authors.Remove(toRemove);
                return await _dbContext.SaveChangesAsync() == 1;
            }
            else
            {
                return false;
            }
        }
    }
}
