using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimeAPI.API.Controllers
{
    [ApiController]
    [Route("api/v1/animes")]
    public class AnimeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return StatusCode(501, "Not implemented.");
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

