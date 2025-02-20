using AnimeAPI.Domain.Entities;

namespace AnimeAPI.Domain.Interfaces;

public interface IAnimeRepository
{
    Task<IEnumerable<Anime>> GetAllAsync(Guid? id = null, string? name = null, string? director = null);
    Task<Anime?> GetByIdAsync(Guid id);
    Task<IEnumerable<Anime>> GetByFiltersAsync(string? name, string? director);
    Task AddAsync(Anime anime);
    Task UpdateAsync(Anime anime);
    Task DeleteAsync(Guid id);
}
