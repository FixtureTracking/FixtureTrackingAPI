using FixtureTracking.Business.Abstract;
using FixtureTracking.Entities.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace FixtureTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var result = authService.Login(userForLoginDto);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var result = authService.Register(userForRegisterDto);
            if (result.Success)
                return CreatedAtAction("GetById", "Users", new { id = result.Data }, result.Message);
            return BadRequest(result.Message);
        }
    }
}
