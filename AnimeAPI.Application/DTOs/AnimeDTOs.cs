using System.ComponentModel.DataAnnotations;

namespace AnimeAPI.Application.DTOs
{
    public class CreateAnimeRequestDto
    {
        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Summary field is required.")]
        public string Summary { get; set; }

        [Required(ErrorMessage = "The Director field is required.")]
        public string Director { get; set; }

    }

    public class UpdateAnimeRequestDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Summary field is required.")]
        public string Summary { get; set; }

        [Required(ErrorMessage = "The Director field is required.")]
        public string Director { get; set; }
    }

}

