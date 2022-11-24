using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoBaEsport.Application.Model.ReplyModel;

namespace MoBaESport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepliesController : ControllerBase
    {
        private readonly IManageReply _manageReply;

        public RepliesController(IManageReply manageReply)
        {
            _manageReply = manageReply;
        }

        [HttpPost("create-reply")]
        public async Task<IActionResult> Create([FromForm] ReplyCreateModel model)
        {
            var result = await _manageReply.Create(model);

            if (result == 0) return BadRequest();

            return Ok(result);
        }

        [HttpPut("update-reply")]
        public async Task<IActionResult> Update([FromForm] ReplyUpdateModel model, [FromQuery]long replyId)
        {
            var result = await _manageReply.Update(model, replyId);

            if (result == 0) return BadRequest();

            return Ok(result);
        }

        [HttpDelete("delete-reply")]
        public async Task<IActionResult> Delete([FromQuery]Guid userid, [FromQuery]long replyId)
        {
            var result = await _manageReply.Delete(userid, replyId);

            if (result == 0) return BadRequest();

            return Ok(result);
        }

        [HttpGet("get-reply")]
        public async Task<IActionResult> GetReply([FromQuery]long replyId)
        {
            var result = await _manageReply.GetReply(replyId);

            if (result == null) return BadRequest();

            return Ok(result);
        }
    }
}
