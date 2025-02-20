using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AnimeAPI.Application.Services;
using AnimeAPI.Domain.Entities;
using AnimeAPI.Application.DTOs;
using System.Threading.Tasks;

namespace AnimeAPI.API.Controllers
{
    [ApiController]
    [Route("api/v1/animes")]
    public class AnimeController : ControllerBase
    {
        private readonly AnimeService _animeService;

        public AnimeController(AnimeService animeService)
        {
            _animeService = animeService;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<Anime>), 200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Anime>>> GetAll([FromQuery] GetAllAnimesByFiltersDto filters)
        {
            var animes = await _animeService.GetAllAsync(filters);
            return Ok(animes);
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Anime), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Create([FromBody] CreateAnimeRequestDto data)
        {
            var anime = await _animeService.CreateAsync(data);
            return StatusCode(201, anime);
        }

        [HttpPut]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Anime), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Update([FromBody] UpdateAnimeRequestDto anime)
        {
            var updatedAnime = await _animeService.UpdateAsync(anime);
            return StatusCode(201, updatedAnime);
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task Delete([FromRoute] Guid id)
        {
            await _animeService.DeleteAsync(id);
        }
    }

}

