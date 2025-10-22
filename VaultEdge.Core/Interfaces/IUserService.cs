using System.Collections.Generic;
using VaultEdge.Core.Models;

namespace VaultEdge.Core.Interfaces
{
    public interface IUserService
    {
        AuthResult CreateUser(UserRegisterRequest request);
        User ValidateUser(string username, string password);
        User GetUserById(string id);
        IEnumerable<User> GetAllUsers();
    }
}
