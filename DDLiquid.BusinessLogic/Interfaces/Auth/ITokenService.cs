namespace DDLiquid.BusinessLogic.Interfaces.Auth
{
    public interface ITokenService
    {
        string GenerateToken(int userId, string username, string role);
    }
}

