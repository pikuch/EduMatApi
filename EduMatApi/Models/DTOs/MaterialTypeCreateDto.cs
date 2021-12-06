using System.ComponentModel.DataAnnotations;

namespace EduMatApi.Models.DTOs
{
    public class MaterialTypeCreateDto
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(1000, MinimumLength = 1)]
        public string Definition { get; set; } = null!;
    }
}
