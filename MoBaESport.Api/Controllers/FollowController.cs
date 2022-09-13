using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoBaEsport.Application.Model.FollowModel;

namespace MoBaESport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        private readonly IManageFollow _manageFollow;

        public FollowController(IManageFollow managefollow)
        {
            _manageFollow = managefollow;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] FollowCreateModel model)
        {
            var result = await _manageFollow.Create(model);

            if (result == 0) return BadRequest();

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid userId, long followId)
        {
            var result = await _manageFollow.Delete(userId, followId);

            if (result == 0) return BadRequest();

            return Ok(result);
        }
    }
}
