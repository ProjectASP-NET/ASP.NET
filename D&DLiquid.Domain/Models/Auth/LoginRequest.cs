using System;
using System.Collections.Generic;
using System.Text;

namespace D_DStore.Domain.Models.Auth
{
    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
