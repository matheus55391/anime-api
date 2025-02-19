using AnimeAPI.Application.DTOs;
using AnimeAPI.Domain.Entities;
using AnimeAPI.Domain.Interfaces;

namespace AnimeAPI.Application.Services
{
    public class AnimeService
    {
        private readonly IAnimeRepository _animeRepository;

        public AnimeService(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }

        public async Task<IEnumerable<Anime>> GetAllAsync()
        {
            return await _animeRepository.GetAllAsync();
        }

        public async Task<Anime> CadastrarAnimeAsync(CreateAnimeRequestDto anime)
        {


            var newAnime = new Anime(anime.Name, anime.Director, anime.Summary);

            await _animeRepository.AddAsync(newAnime);
            return newAnime;
        }
    }
}

