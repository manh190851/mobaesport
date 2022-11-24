using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoBaEsport.Application.Model.FriendModel;

namespace MoBaESport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        private readonly IManageFriend _manageFriend;
        public FriendsController(IManageFriend manageFriend)
        {
            _manageFriend = manageFriend;
        }

        [HttpPost("create-friend-request")]
        public async Task<IActionResult> CreateRequest([FromBody] FriendCreateModel model)
        {
            var result = await _manageFriend.CreateRequest(model);

            if (result == 0) return BadRequest();

            return Ok(result);
        }

        [HttpGet("get-list-friend-request")]
        public async Task<IActionResult> GetFriendRequest([FromQuery] Guid userId)
        {
            var result = await _manageFriend.GetFriendRequest(userId);
            
            if(result == null) return BadRequest();

            return Ok(result);
        }

        [HttpPatch("confirm-request")]
        public async Task<IActionResult> ConfirmRequest([FromQuery]long friendId)
        {
            var result = await _manageFriend.ConfirmRequest(friendId);

            if (result == 0) return BadRequest();

            return Ok(result);
        }

        [HttpDelete("delete-friend")]
        public async Task<IActionResult> Delete([FromQuery]long friendId)
        {
            var result = await _manageFriend.Delete(friendId);

            if (result == 0) return BadRequest();

            return Ok(result);
        }

        [HttpGet("get-friend")]
        public async Task<IActionResult> GetFriend([FromQuery] Guid userId, [FromQuery] Guid targetId)
        {
            var result = await _manageFriend.GetFriend(userId, targetId);
            if (result == null) return BadRequest();

            return Ok(result);
        }

        [HttpGet("get-list-friend")]
        public async Task<IActionResult> GetFriendList([FromQuery]Guid userId)
        {
            var result = await _manageFriend.GetListFriend(userId);
            if (result == null) return BadRequest();

            return Ok(result);
        }
    }
}
