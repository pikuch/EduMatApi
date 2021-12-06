using System.ComponentModel.DataAnnotations;

namespace EduMatApi.Models.Entities
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MaterialId { get; set; }
        public Material? Material { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 1)]
        public string Opinion { get; set; } = null!;

        [Required]
        [Range(0, 10)]
        public int Score { get; set; }
    }
}
