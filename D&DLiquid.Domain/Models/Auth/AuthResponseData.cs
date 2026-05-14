namespace D_DStore.Domain.Models.Auth
{
    public class AuthResponseData
    {
        public string Token { get; set; } = string.Empty;
        public UserResponseData User { get; set; } = new UserResponseData();
    }
}
