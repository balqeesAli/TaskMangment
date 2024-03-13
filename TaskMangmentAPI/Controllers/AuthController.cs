using Microsoft.AspNetCore.Mvc;
using TaskMangmentAPI.Infrastructure.DTOs;
using TaskMangmentAPI.Services.IServices;

namespace TaskMangmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;

        public AuthController(IAuthServices authServices)
        {
            _authServices  = authServices;
        }
         
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationDto registerRequest)
        {
            try
            {
                var response = await _authServices.Register(registerRequest);
                 return StatusCode(response.result, response); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] loginDto loginDto)
        {
            try
            {
                var response = await _authServices.Login(loginDto);
                return StatusCode(response.result, response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        } 
    }
}
