using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoBaEsport.Application.Model.FriendModel;

namespace MoBaESport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IManageFriend _manageFriend;
        public FriendController(IManageFriend manageFriend)
        {
            _manageFriend = manageFriend;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest([FromForm] FriendCreateModel model)
        {
            var result = await _manageFriend.CreateRequest(model);

            if (result == 0) return BadRequest();

            return Ok(result);
        }

        [HttpPut("{friendId}")]
        public async Task<IActionResult> AcceptRequest(long friendId)
        {
            var result = await _manageFriend.AccepRequest(friendId);

            if (result == 0) return BadRequest();

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid userId, long friendId)
        {
            var result = await _manageFriend.Delete(userId, friendId);

            if (result == 0) return BadRequest();

            return Ok(result);
        }
    }
}
