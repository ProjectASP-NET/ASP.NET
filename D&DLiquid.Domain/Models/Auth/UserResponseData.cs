namespace D_DStore.Domain.Models.Auth
{
    public class UserResponseData
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime RegisteredOn { get; set; }
    }
}
