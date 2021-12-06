using System.ComponentModel.DataAnnotations;

namespace EduMatApi.Models.DTOs
{
    public class AuthorCreateDto
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(1000, MinimumLength = 1)]
        public string Description { get; set; } = null!;
    }
}
