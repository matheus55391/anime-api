using MediaAPI.Application.DTOs;
using MediaAPI.Domain.Entities;
using MediaAPI.Domain.Interfaces;

namespace MediaAPI.Application.Services
{
    public class MediaService
    {
        private readonly IMediaRepository _mediaRepository;

        public MediaService(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }

        public async Task<IEnumerable<Media>> GetAllAsync(GetAllMediasByFiltersDto filters)
        {
            return await _mediaRepository.GetAllAsync(filters.Id, filters.Name, filters.Director);
        }

        public async Task<Media> CreateAsync(CreateMediaRequestDto media)
        {
            var newMedia = new Media(media.Name, media.Director, media.Summary);

            await _mediaRepository.AddAsync(newMedia);
            return newMedia;
        }


        public async Task<Media> UpdateAsync(UpdateMediaRequestDto media)
        {
            var updatedMedia = new Media(
                media.Id,
                media.Name,
                media.Director,
                media.Summary
            );
            await _mediaRepository.UpdateAsync(updatedMedia);

            return updatedMedia;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _mediaRepository.DeleteAsync(id);
        }
    }
}

