using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoBaEsport.Application.Systems.UserServiceModel;

namespace MoBaESport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService; 
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromForm]LoginRequestModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultToken = await _userService.Login(model);
            if (string.IsNullOrEmpty(resultToken))
            {
                return BadRequest("Username or password is incorrect!");
            }
            return Ok(new { token = resultToken});
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.Register(model);
            if (!result)
            {
                return BadRequest("Register unsuccessfully");
            }
            return Ok();
        }
    }
}
