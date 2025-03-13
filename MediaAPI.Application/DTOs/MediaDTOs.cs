using System.ComponentModel.DataAnnotations;

namespace MediaAPI.Application.DTOs
{
    public class CreateMediaRequestDto
    {
        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Summary field is required.")]
        public string Summary { get; set; }

        [Required(ErrorMessage = "The Director field is required.")]
        public string Director { get; set; }

    }

    public class UpdateMediaRequestDto
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

    public class GetAllMediasByFiltersDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Director { get; set; }
    }


}

