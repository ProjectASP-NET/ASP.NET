using System;
using System.Collections.Generic;
using System.Text;

namespace D_DStore.Domain.Models.Auth
{
    public class AuthResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? Token { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public string? Role { get; set; }
    }
}
