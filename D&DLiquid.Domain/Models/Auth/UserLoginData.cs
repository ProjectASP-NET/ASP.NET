using System.ComponentModel.DataAnnotations;

namespace D_DStore.Domain.Models.Auth
{
    public class UserLoginData
    {
        [Required]
        public string Login { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
