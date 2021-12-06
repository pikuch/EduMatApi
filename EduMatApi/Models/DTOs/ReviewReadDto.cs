namespace EduMatApi.Models.DTOs
{
    public class ReviewReadDto
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public string Opinion { get; set; } = null!;
        public int Score { get; set; }
    }
}
