namespace DDLiquid.Domain.Models.Auth
{
    public class UserResponseData
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public RoleResponseData Role { get; set; } = null!;
        public DateTime RegisteredOn { get; set; }
    }
}

