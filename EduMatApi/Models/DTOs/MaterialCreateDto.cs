using System.ComponentModel.DataAnnotations;

namespace EduMatApi.Models.DTOs
{
    public class MaterialCreateDto
    {
        public int AuthorId { get; set; }
        public int MaterialTypeId { get; set; }
        
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
    }
}
