namespace EduMatApi.Models.DTOs
{
    public class MaterialReadDto
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int MaterialTypeId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateTime PublishDate { get; set; }
    }
}
