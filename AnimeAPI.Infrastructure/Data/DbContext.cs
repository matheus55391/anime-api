using AnimeAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimeAPI.Infrastructure.Data
{
    public class AnimeDbContext : DbContext
    {
        public AnimeDbContext(DbContextOptions<AnimeDbContext> options) : base(options) { }

        public DbSet<Anime> Animes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
