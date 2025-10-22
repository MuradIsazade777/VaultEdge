using System.Collections.Generic;
using System.Linq;
using VaultEdge.Core.Interfaces;
using VaultEdge.Core.Models;

namespace VaultEdge.Core.Services
{
    public class UserService : IUserService
    {
        private readonly List<User> _users = new();

        public AuthResult CreateUser(UserRegisterRequest request)
        {
            if (_users.Any(u => u.Username == request.Username))
                return new AuthResult { Success = false, Message = "Username already exists" };

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = HashPassword(request.Password)
            };

            _users.Add(user);
            return new AuthResult { Token = "dummy-token", Message = "User created" };
        }

        public User ValidateUser(string username, string password)
        {
            var hash = HashPassword(password);
            return _users.FirstOrDefault(u => u.Username == username && u.PasswordHash == hash);
        }

        public User GetUserById(string id) => _users.FirstOrDefault(u => u.Id == id);

        public IEnumerable<User> GetAllUsers() => _users;

        private string HashPassword(string password)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
