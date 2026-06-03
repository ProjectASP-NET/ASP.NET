using System.ComponentModel.DataAnnotations;

namespace DDLiquid.Domain.Models.Auth
{
    public class UserLoginData
    {
        [Required]
        public string Login { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}

