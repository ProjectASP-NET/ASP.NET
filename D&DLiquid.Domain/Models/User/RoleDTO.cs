using System;
using System.Collections.Generic;
using System.Text;

namespace D_DStore.Domain.Models.User
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
