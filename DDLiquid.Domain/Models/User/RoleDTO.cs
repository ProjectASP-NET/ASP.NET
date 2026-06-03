using System;
using System.Collections.Generic;
using System.Text;

namespace DDLiquid.Domain.Models.User
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}

