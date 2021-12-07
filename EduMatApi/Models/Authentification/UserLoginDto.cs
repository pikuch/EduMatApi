using System.ComponentModel.DataAnnotations;

namespace EduMatApi.Models.Authentification
{
    public class UserLoginDto
    {
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Login { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Password { get; set; } = null!;
    }
}
