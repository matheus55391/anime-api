using AnimeAPI.Domain.Entities;

namespace AnimeAPI.Domain.Interfaces;

public interface IAnimeRepository
{
    Task<IEnumerable<Anime>> GetAllAsync();
    Task<Anime?> GetByIdAsync(Guid id);
    Task<IEnumerable<Anime>> GetByFiltersAsync(string? name, string? director);
    Task AddAsync(Anime anime);
    Task UpdateAsync(Anime anime);
    Task DeleteAsync(Guid id);
}
