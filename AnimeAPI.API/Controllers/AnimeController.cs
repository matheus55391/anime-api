using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AnimeAPI.Application.Services;
using AnimeAPI.Domain.Entities;

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
        [Authorize]
        public IActionResult Create([FromBody] AnimeDto anime)
        {
            return StatusCode(501, "Not implemented.");
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Update(int id, [FromBody] AnimeDto anime)
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

    public class AnimeDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Diretor { get; set; }
        public string Resumo { get; set; }
    }
}

