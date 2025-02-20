using AnimeAPI.Domain.Entities;
using AnimeAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using AnimeAPI.Infrastructure.Data;

namespace AnimeAPI.Infrastructure.Repositories
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly AnimeDbContext _context;

        public AnimeRepository(AnimeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Anime>> GetAllAsync(Guid? id = null, string? name = null, string? director = null)
        {
            var query = _context.Animes.AsQueryable();

            if (id.HasValue)
                query = query.Where(a => a.Id == id);

            if (!string.IsNullOrEmpty(name))
                query = query.Where(a => a.Name.Contains(name));

            if (!string.IsNullOrEmpty(director))
                query = query.Where(a => a.Director.Contains(director));

            return await query.ToListAsync();
        }

        public async Task<Anime?> GetByIdAsync(Guid id)
        {
            return await _context.Animes.FindAsync(id);
        }

        public async Task<IEnumerable<Anime>> GetByFiltersAsync(string? name, string? director)
        {
            var query = _context.Animes.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(a => a.Name.Contains(name));

            if (!string.IsNullOrEmpty(director))
                query = query.Where(a => a.Director.Contains(director));

            return await query.ToListAsync();
        }

        public async Task AddAsync(Anime anime)
        {
            await _context.Animes.AddAsync(anime);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Anime anime)
        {
            _context.Animes.Update(anime);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var anime = await _context.Animes.FindAsync(id);
            if (anime != null)
            {
                _context.Animes.Remove(anime);
                await _context.SaveChangesAsync();
            }
        }
    }
}
