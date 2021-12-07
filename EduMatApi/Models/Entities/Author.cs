using System.ComponentModel.DataAnnotations;

namespace EduMatApi.Models.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(1000, MinimumLength = 1)]
        public string Description { get; set; } = null!;

        public int MaterialCounter { get; set; }
        public ICollection<Material>? Materials { get; set; }
    }
}
