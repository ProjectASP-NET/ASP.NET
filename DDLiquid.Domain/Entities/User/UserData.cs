using DDLiquid.Domain.Entities.References;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DDLiquid.Domain.Entities.User
{
    public class UserData : Refs
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(15)]
        public string NickName { get; set; } = string.Empty;
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public RoleData Role { get; set; } = null!;
    }
}

