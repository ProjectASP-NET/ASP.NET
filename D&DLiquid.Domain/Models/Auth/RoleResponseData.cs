namespace D_DStore.Domain.Models.Auth
{
    public class RoleResponseData
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
