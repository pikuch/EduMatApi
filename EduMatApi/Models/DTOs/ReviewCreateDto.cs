using System.ComponentModel.DataAnnotations;

namespace EduMatApi.Models.DTOs
{
    public class ReviewCreateDto
    {
        public int MaterialId { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 1)]
        public string Opinion { get; set; } = null!;

        [Required]
        [Range(0, 10)]
        public int Score { get; set; }
    }
}
