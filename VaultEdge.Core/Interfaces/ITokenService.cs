using VaultEdge.Core.Models;

namespace VaultEdge.Core.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        string RefreshToken(string oldToken);
    }
}
