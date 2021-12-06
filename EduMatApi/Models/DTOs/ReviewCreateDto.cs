using System.ComponentModel.DataAnnotations;

namespace EduMatApi.Models.DTOs
{
    public class ReviewCreateDto
    {
        [Required]
        public int MaterialId { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Opinion text has to be between 1 and 1000 characters long")]
        public string Opinion { get; set; } = null!;

        [Required]
        [Range(0, 10, ErrorMessage = "Review score has to be between 0 and 10")]
        public int Score { get; set; }
    }
}
