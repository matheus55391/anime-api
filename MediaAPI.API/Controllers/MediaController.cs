using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediaAPI.Application.Services;
using MediaAPI.Domain.Entities;
using MediaAPI.Application.DTOs;
using System.Threading.Tasks;

namespace MediaAPI.API.Controllers
{
    [ApiController]
    [Route("api/v1/medias")]
    public class MediaController : ControllerBase
    {
        private readonly MediaService _mediaService;

        public MediaController(MediaService mediaService)
        {
            _mediaService = mediaService;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<Media>), 200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Media>>> GetAll([FromQuery] GetAllMediasByFiltersDto filters)
        {
            var medias = await _mediaService.GetAllAsync(filters);
            return Ok(medias);
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Media), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Create([FromBody] CreateMediaRequestDto data)
        {
            var media = await _mediaService.CreateAsync(data);
            return StatusCode(201, media);
        }

        [HttpPut]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Media), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Update([FromBody] UpdateMediaRequestDto media)
        {
            var updatedMedia = await _mediaService.UpdateAsync(media);
            return StatusCode(201, updatedMedia);
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task Delete([FromRoute] Guid id)
        {
            await _mediaService.DeleteAsync(id);
        }
    }

}

