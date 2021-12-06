using System.ComponentModel.DataAnnotations;

namespace EduMatApi.Models.Entities
{
    public class MaterialType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(1000, MinimumLength = 1)]
        public string Definition { get; set; } = null!;

        public ICollection<Material>? Materials { get; set;}
    }
}
