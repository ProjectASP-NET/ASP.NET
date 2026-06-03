using AutoMapper;
using DDLiquid.DataAccess.Interfaces;
using DDLiquid.BusinessLogic.Interfaces.Auth;
using DDLiquid.Domain.Entities.User;
using DDLiquid.Domain.Models.Auth;

namespace DDLiquid.BusinessLogic.Services.Auth
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper,
            IPasswordHasher passwordHasher,
            ITokenService tokenService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task<IEnumerable<UserResponseData>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserResponseData>>(users);
        }

        public async Task<UserResponseData?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user == null ? null : _mapper.Map<UserResponseData>(user);
        }

        public async Task<AuthResponseData> RegisterAsync(UserRegisterData data)
        {
            var role = data.Role?.Trim();
            if (string.IsNullOrEmpty(role) ||
                role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Registration is only allowed for User or Manager roles");
            }

            var existingByEmail = await _userRepository.GetByEmailAsync(data.Email);
            if (existingByEmail != null)
                throw new InvalidOperationException("Email already exists");

            var existingByNickName = await _userRepository.GetByNickNameAsync(data.Username);
            if (existingByNickName != null)
                throw new InvalidOperationException("Username already exists");

            var userRole = _userRepository.GetRoleByName(role);
            if (userRole == null)
                throw new InvalidOperationException($"Role '{role}' not found in database");

            var user = new UserData
            {
                NickName = data.Username,
                Email = data.Email,
                PasswordHash = _passwordHasher.Hash(data.Password),
                RoleId = userRole.Id
            };

            var created = await _userRepository.CreateAsync(user);

            // Reload with role included
            var createdWithRole = await _userRepository.GetByIdAsync(created.Id);

            var token = _tokenService.GenerateToken(createdWithRole!.Id, createdWithRole.NickName, createdWithRole.Role.Name);

            return new AuthResponseData
            {
                Token = token,
                User = _mapper.Map<UserResponseData>(createdWithRole)
            };
        }

        public async Task<AuthResponseData?> LoginAsync(UserLoginData data)
        {
            var user = await _userRepository.GetByEmailAsync(data.Login)
                       ?? await _userRepository.GetByNickNameAsync(data.Login);

            if (user == null || !_passwordHasher.Verify(data.Password, user.PasswordHash))
                return null;

            var token = _tokenService.GenerateToken(user.Id, user.NickName, user.Role.Name);

            return new AuthResponseData
            {
                Token = token,
                User = _mapper.Map<UserResponseData>(user)
            };
        }

        public async Task<UserResponseData?> UpdateAsync(int id, UserUpdateData data)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;

            if (data.Email != null) user.Email = data.Email;
            if (data.Username != null) user.NickName = data.Username;

            var updated = await _userRepository.UpdateAsync(id, user);
            return updated == null ? null : _mapper.Map<UserResponseData>(updated);
        }

        public async Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) return false;

            if (!_passwordHasher.Verify(currentPassword, user.PasswordHash))
                return false;

            user.PasswordHash = _passwordHasher.Hash(newPassword);
            await _userRepository.UpdateAsync(userId, user);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return false;
            await _userRepository.DeleteAsync(id);
            return true;
        }
    }
}

