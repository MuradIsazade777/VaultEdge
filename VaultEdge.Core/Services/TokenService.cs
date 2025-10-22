using VaultEdge.Core.Interfaces;
using VaultEdge.Core.Models;

namespace VaultEdge.Core.Services
{
    public class TokenService : ITokenService
    {
        public string GenerateToken(User user)
        {
            return $"token-{user.Id}-{DateTime.UtcNow.Ticks}";
        }

        public string RefreshToken(string oldToken)
        {
            if (string.IsNullOrEmpty(oldToken)) return null;
            return $"refreshed-{DateTime.UtcNow.Ticks}";
        }
    }
}
