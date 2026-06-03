using DDLiquid.Domain.Models.Auth;

namespace DDLiquid.BusinessLogic.Interfaces.Auth
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseData>> GetAllAsync();
        Task<UserResponseData?> GetByIdAsync(int id);
        Task<AuthResponseData> RegisterAsync(UserRegisterData data);
        Task<AuthResponseData?> LoginAsync(UserLoginData data);
        Task<UserResponseData?> UpdateAsync(int id, UserUpdateData data);
        Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword);
        Task<bool> DeleteAsync(int id);
    }
}

