using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoBaEsport.Application.Model.FollowModel;

namespace MoBaESport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowsController : ControllerBase
    {
        private readonly IManageFollow _manageFollow;

        public FollowsController(IManageFollow managefollow)
        {
            _manageFollow = managefollow;
        }

        [HttpPost("create-follow")]
        public async Task<IActionResult> Create([FromBody] FollowCreateModel model)
        {
            var result = await _manageFollow.Create(model);

            if (result == false) return BadRequest();

            return Ok(result);
        }

        [HttpDelete("delete-follow")]
        public async Task<IActionResult> Delete([FromQuery]long followId)
        {
            var result = await _manageFollow.Delete(followId);

            if (result == false) return BadRequest();

            return Ok(result);
        }

        [HttpGet("find-follow")]
        public async Task<IActionResult> FindFollow([FromQuery] Guid targetId, [FromQuery] Guid userId)
        {
            var result = await _manageFollow.GetFollow(targetId, userId);

            if (result == null) return BadRequest();

            return Ok(result);
        }
    }
}
