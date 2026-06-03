using System.ComponentModel.DataAnnotations;

namespace DDLiquid.Domain.Models.Auth
{
    public class ChangePasswordData
    {
        [Required]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string NewPassword { get; set; } = string.Empty;
    }
}

