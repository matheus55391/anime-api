using MediaAPI.Domain.Entities;

namespace MediaAPI.Domain.Interfaces;

public interface IMediaRepository
{
    Task<IEnumerable<Media>> GetAllAsync(Guid? id, string? name, string? director);
    Task AddAsync(Media media);
    Task UpdateAsync(Media media);
    Task DeleteAsync(Guid id);
}
