namespace VaultEdge.Core.Models
{
    public class AuthResult
    {
        public string Token { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; }
    }

    public class TokenRefreshRequest
    {
        public string Token { get; set; }
    }
}
