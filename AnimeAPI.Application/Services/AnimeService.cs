﻿using AnimeAPI.Application.DTOs;
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

        public async Task<IEnumerable<Anime>> GetAllAsync(GetAllAnimesByFiltersDto filters)
        {
            return await _animeRepository.GetAllAsync(filters.Id, filters.Name, filters.Director);
        }

        public async Task<Anime> CreateAsync(CreateAnimeRequestDto anime)
        {
            var newAnime = new Anime(anime.Name, anime.Director, anime.Summary);

            await _animeRepository.AddAsync(newAnime);
            return newAnime;
        }


        public async Task<Anime> UpdateAsync(UpdateAnimeRequestDto anime)
        {
            var updatedAnime = new Anime(
                anime.Id,
                anime.Name,
                anime.Director,
                anime.Summary
            );
            await _animeRepository.UpdateAsync(updatedAnime);

            return updatedAnime;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _animeRepository.DeleteAsync(id);
        }
    }
}

