using EduMatApi.Models.Authentification;
using Microsoft.EntityFrameworkCore;

namespace EduMatApi.DAL
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public UserDbContext(DbContextOptions<UserDbContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Login = "admin", Email = "a@b.c", Password = "admin", Role = "Admin"}
                );
        }
    }
}
