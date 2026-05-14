using System.ComponentModel.DataAnnotations;

namespace D_DStore.Domain.Models.Auth
{
    public class UserRegisterData
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string NickName { get; set; } = string.Empty;
        [Required]
        [MinLength(6)]
        [MaxLength(100)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        [RegularExpression(@"^(User|Manager|Admin)$")]
        public string Role { get; set; } = "User";
    }
}
