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
        [ProducesResponseType(typeof(IEnumerable<Anime>), 200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Anime>>> GetAll()
        {
            var animes = await _animeService.GetAllAsync();
            return Ok(animes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return StatusCode(501, "Not implemented.");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAnimeRequestDto data)
        {
            var anime = await _animeService.CadastrarAnimeAsync(data);
            return StatusCode(201, anime);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Update(int id, [FromBody] CreateAnimeRequestDto anime)
        {
            return StatusCode(501, "Not implemented.");
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            return StatusCode(501, "Not implemented.");
        }
    }

}

