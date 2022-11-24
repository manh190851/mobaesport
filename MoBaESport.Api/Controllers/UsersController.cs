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
        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultToken = await _userService.Login(model);
            if (string.IsNullOrEmpty(resultToken))
            {
                return BadRequest("Username or password is incorrect!");
            }
            return Ok(resultToken);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.Register(model);
            if (string.IsNullOrEmpty(result))
            {
                return BadRequest("Register unsuccessfully");
            }
            return Ok(result);
        }

        [HttpGet("get-list-user")]
        public async Task<IActionResult> GetListUser()
        {
            var users = await _userService.GetListUser();

            if (User == null) return BadRequest();

            return Ok(users);
        }

        [HttpGet("get-profile-user")]
        public async Task<IActionResult> GetProfileUser([FromQuery]Guid userId)
        {
            var user = await _userService.GetUserProfile(userId);

            if (user == null) { return BadRequest(); }

            return Ok(user);
        }

        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateProfile([FromBody]UserUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _userService.UpdateProfile(model.Id, model);
            if(result == false)
            {
                return BadRequest("Update Failed");
            }
            return Ok();
        }

        [HttpGet("get-user-byId/{userId}")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            if(userId == Guid.Empty) { return BadRequest("Id is Empty!"); }
            var user = await _userService.GetUserById(userId);
            if(user == null) { return BadRequest("User Not Found!"); }
            return Ok(user);

        }

    }
}
