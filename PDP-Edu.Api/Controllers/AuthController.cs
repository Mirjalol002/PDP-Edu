using Microsoft.AspNetCore.Mvc;
using PDP_Edu.Api.Models;
using PDP_Edu.Infrastructure.Abstractions;

namespace PDP_Edu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
        {
            return Ok(await _authService.LoginAsync(loginRequest.UserName, loginRequest.Password));
        }
    }
}