using DDLiquid.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DDLiquid.Domain.Models.User
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string NickName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public RoleData Role { get; set; } = null!;

    }
}

