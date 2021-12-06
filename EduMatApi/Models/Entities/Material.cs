using System.ComponentModel.DataAnnotations;

namespace EduMatApi.Models.Entities
{
    public class Material
    {
        [Key]
        public int Id { get; set; }

        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        public int MaterialTypeId { get; set; }
        public MaterialType? MaterialType { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(1000, MinimumLength = 1)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(1000, MinimumLength = 1)]
        public string Location { get; set; } = null!;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PublishDate { get; set; }

        public ICollection<Review>? Reviews { get; set; }
    }
}
