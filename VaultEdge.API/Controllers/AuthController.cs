using Microsoft.AspNetCore.Mvc;
using VaultEdge.Core.Interfaces;
using VaultEdge.Core.Models;

namespace VaultEdge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public AuthController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginRequest request)
        {
            var user = _userService.ValidateUser(request.Username, request.Password);
            if (user == null)
                return Unauthorized("Invalid credentials");

            var token = _tokenService.GenerateToken(user);
            return Ok(new AuthResult { Token = token });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterRequest request)
        {
            var result = _userService.CreateUser(request);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("refresh")]
        public IActionResult RefreshToken([FromBody] TokenRefreshRequest request)
        {
            var newToken = _tokenService.RefreshToken(request.Token);
            if (string.IsNullOrEmpty(newToken))
                return Unauthorized("Invalid token");

            return Ok(new AuthResult { Token = newToken });
        }
    }
}
