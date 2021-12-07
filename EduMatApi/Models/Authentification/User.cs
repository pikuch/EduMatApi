using System.ComponentModel.DataAnnotations;

namespace EduMatApi.Models.Authentification
{
    public class User
    {
        [Key]
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Login { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 1)]  // Too short for production, too long for testing
        public string Password { get; set; } = null!;

        public string Role { get; set; } = null!;
    }
}
