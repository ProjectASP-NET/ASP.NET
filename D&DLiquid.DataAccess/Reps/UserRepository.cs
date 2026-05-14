using D_DLiquid.DataAccess.Interfaces;
using D_DStore.DataAccess.DB;
using D_DStore.DataAccess.Reps;
using D_DStore.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace D_DLiquid.DataAccess.Reps
{
    public class UserRepository : UserContextRepository<UserData>, IUserRepository
    {
        private readonly UserDbContext _userContext;

        public UserRepository(UserDbContext context) : base(context)
        {
            _userContext = context;
        }

        public UserData? GetByEmail(string email)
        {
            return _userContext.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == email);
        }

        public UserData? GetByNickName(string nickName)
        {
            return _userContext.Users.Include(u => u.Role).FirstOrDefault(u => u.NickName == nickName);
        }

        public bool ExistsByEmail(string email)
        {
            return _userContext.Users.Any(u => u.Email == email);
        }

        public bool ExistsByNickName(string nickName)
        {
            return _userContext.Users.Any(u => u.NickName == nickName);
        }

        public RoleData? GetRoleByName(string roleName)
        {
            return _userContext.Roles.FirstOrDefault(r => r.Name == roleName);
        }

        public async Task<UserData?> GetByEmailAsync(string email)
        {
            return await _userContext.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<UserData?> GetByNickNameAsync(string nickName)
        {
            return await _userContext.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.NickName == nickName);
        }

        public override async Task<UserData?> GetByIdAsync(int id)
        {
            return await _userContext.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == id);
        }

        public override async Task<IEnumerable<UserData>> GetAllAsync()
        {
            return await _userContext.Users.Include(u => u.Role).ToListAsync();
        }
    }
}
