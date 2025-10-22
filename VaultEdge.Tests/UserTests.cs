using Xunit;
using VaultEdge.Core.Services;
using VaultEdge.Core.Models;
using System.Linq;

namespace VaultEdge.Tests
{
    public class UserTests
    {
        [Fact]
        public void Should_Create_And_Fetch_User()
        {
            var service = new UserService();

            var request = new UserRegisterRequest
            {
                Username = "neo",
                Password = "matrix",
                Email = "neo@vault.com"
            };

            var result = service.CreateUser(request);
            Assert.True(result.Success);

            var user = service.GetUserById(result.Token.Split('-')[1]);
            Assert.NotNull(user);
            Assert.Equal("neo", user.Username);
        }

        [Fact]
        public void Should_Not_Allow_Duplicate_Username()
        {
            var service = new UserService();

            var req1 = new UserRegisterRequest { Username = "admin", Password = "123", Email = "a@a.com" };
            var req2 = new UserRegisterRequest { Username = "admin", Password = "456", Email = "b@b.com" };

            var res1 = service.CreateUser(req1);
            var res2 = service.CreateUser(req2);

            Assert.True(res1.Success);
            Assert.False(res2.Success);
        }
    }
}
