\using MediaAPI.Domain.Entities;
using MediaAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using MediaAPI.Infrastructure.Data;

namespace MediaAPI.Infrastructure.Repositories
{
    public class MediaRepository : IMediaRepository
    {
        private readonly MediaDbContext _context;

        public MediaRepository(MediaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Media>> GetAllAsync(Guid? id, string? name, string? director)
        {
            var query = _context.Medias.AsQueryable();

            if (id.HasValue)
                query = query.Where(a => a.Id == id);

            if (!string.IsNullOrEmpty(name))
                query = query.Where(a => a.Name.Contains(name));

            if (!string.IsNullOrEmpty(director))
                query = query.Where(a => a.Director.Contains(director));

            return await query.ToListAsync();
        }

        public async Task AddAsync(Media media)
        {
            await _context.Medias.AddAsync(media);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Media media)
        {
            _context.Medias.Update(media);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var media = await _context.Medias.FindAsync(id);
            if (media != null)
            {
                _context.Medias.Remove(media);
                await _context.SaveChangesAsync();
            }
        }
    }
}
