using ForgeXAPI.Dtos;
using ForgeXAPI.Helpers;
using ForgeXAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForgeXAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtHelper _jwt;

        public AuthController(IUserService userService, JwtHelper jwt)
        {
            _userService = userService;
            _jwt = jwt;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
        {
            var user = await _userService.RegisterAsync(dto);
            if (user == null)
                return BadRequest(new { error = "Registration failed" });

            return Ok(new { message = "Registration successful, pending approval" });
        }

        [HttpPost("approve/{userId}")]
        public async Task<IActionResult> ApproveUser(int userId)
        {
           var resp = await _userService.ApproveUserAsync(userId);
              if (resp == null)
                return NotFound(new { error = "User not found" });
            return Ok(new { message = "User approved successfully" });
        }

        [HttpPost("unapprove/{userId}")]
        public async Task<IActionResult> UnapproveUser(int userId)  
        {
           var resp = await _userService.UnapproveUserAsync(userId);
              if (resp == null)
                return NotFound(new { error = "User not found" });
            return Ok(new { message = "User unapproved successfully" });
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            var user = await _userService.AuthenticateAsync(dto);
            if (user == null)
                return Unauthorized(new { error = "Invalid credentials" });

            var token = _jwt.GenerateToken(user);
            return Ok(new { token, userId = user.Id });
        }
    

        [HttpGet("getallusers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
    }
}
