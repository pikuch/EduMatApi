using System.ComponentModel.DataAnnotations;

namespace EduMatApi.Models.DTOs
{
    public class MaterialUpdateDto
    {
        [Required]
        public int AuthorId { get; set; }

        [Required]
        public int MaterialTypeId { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Title has to be between 1 and 100 characters long")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Description has to be between 1 and 1000 characters long")]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Location has to be between 1 and 1000 characters long")]
        public string Location { get; set; } = null!;

        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date format")]
        [Range(typeof(DateTime), "2000-01-01", "3000-01-01", ErrorMessage = "Date has to be between 2000-01-01 and 3000-01-01")]
        public DateTime PublishDate { get; set; }
    }
}
