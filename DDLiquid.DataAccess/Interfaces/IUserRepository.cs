using DDLiquid.Domain.Entities.User;

namespace DDLiquid.DataAccess.Interfaces
{
    public interface IUserRepository : IRepository<UserData>
    {
        UserData? GetByEmail(string email);
        UserData? GetByNickName(string nickName);
        bool ExistsByEmail(string email);
        bool ExistsByNickName(string nickName);
        RoleData? GetRoleByName(string roleName);

        Task<UserData?> GetByEmailAsync(string email);
        Task<UserData?> GetByNickNameAsync(string nickName);
    }
}

