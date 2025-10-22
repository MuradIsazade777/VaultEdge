using Xunit;
using VaultEdge.Core.Services;
using VaultEdge.Core.Models;

namespace VaultEdge.Tests
{
    public class AuthTests
    {
        [Fact]
        public void Should_Create_User_And_Generate_Token()
        {
            var userService = new UserService();
            var tokenService = new TokenService();

            var request = new UserRegisterRequest
            {
                Username = "murad",
                Password = "secure123",
                Email = "murad@example.com"
            };

            var result = userService.CreateUser(request);
            Assert.True(result.Success);

            var user = userService.ValidateUser("murad", "secure123");
            Assert.NotNull(user);

            var token = tokenService.GenerateToken(user);
            Assert.NotNull(token);
            Assert.Contains("token-", token);
        }
    }
}
