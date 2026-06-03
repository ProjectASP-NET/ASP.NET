using DDLiquid.Domain.Entities.References;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DDLiquid.Domain.Entities.User
{
    public class RoleData : Refs
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ICollection<UserData> Users { get; set; } = new List<UserData>();
    }
}

