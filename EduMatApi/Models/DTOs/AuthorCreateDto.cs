using System.ComponentModel.DataAnnotations;

namespace EduMatApi.Models.DTOs
{
    public class AuthorCreateDto
    {
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Author name has to be between 1 and 100 characters long")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Description has to be between 1 and 1000 characters long")]
        public string Description { get; set; } = null!;
    }
}
