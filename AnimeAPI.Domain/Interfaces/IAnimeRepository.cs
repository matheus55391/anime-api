using AnimeAPI.Domain.Entities;

namespace AnimeAPI.Domain.Interfaces;

public interface IAnimeRepository
{
    Task<IEnumerable<Anime>> GetAllAsync(Guid? id, string? name, string? director);
    Task AddAsync(Anime anime);
    Task UpdateAsync(Anime anime);
    Task DeleteAsync(Guid id);
}
