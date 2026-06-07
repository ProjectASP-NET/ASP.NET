using System.ComponentModel.DataAnnotations;

namespace DDLiquid.Domain.Models.Auth
{
    public class UserRegisterData
    {
        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string Username { get; set; } = string.Empty;
        [Required]
        [MinLength(6)]
        [MaxLength(100)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        [RegularExpression(@"^(User|Manager|Admin)$")]
        public string Role { get; set; } = "User";
    }
}

