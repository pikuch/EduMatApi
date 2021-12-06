using EduMatApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduMatApi.DAL
{
    public class EduMatApiDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Material> Materials { get; set; } = null!;
        public DbSet<MaterialType> MaterialTypes { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;

        public EduMatApiDbContext(DbContextOptions<EduMatApiDbContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
        }
    }
}
