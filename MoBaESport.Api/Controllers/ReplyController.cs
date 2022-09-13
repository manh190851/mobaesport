using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoBaEsport.Application.Model.ReplyModel;

namespace MoBaESport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReplyController : ControllerBase
    {
        private readonly IManageReply _manageReply;

        public ReplyController(IManageReply manageReply)
        {
            _manageReply = manageReply;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ReplyCreateModel model)
        {
            var result = await _manageReply.Create(model);

            if (result == 0) return BadRequest();

            return Ok(result);
        }

        [HttpPut("{replyId}")]
        public async Task<IActionResult> Update([FromForm] ReplyUpdateModel model, long replyId)
        {
            var result = await _manageReply.Update(model, replyId);

            if (result == 0) return BadRequest();

            return Ok(result);
        }

        [HttpDelete("{replyId}")]
        public async Task<IActionResult> Delete(Guid userid, long replyId)
        {
            var result = await _manageReply.Delete(userid, replyId);

            if (result == 0) return BadRequest();

            return Ok(result);
        }

        [HttpGet("view-reply-reaction/{replyId}")]
        public async Task<IActionResult> ViewListReaction(long replyId)
        {
            var result = await _manageReply.ViewListReaction(replyId);

            if (result == null) return BadRequest();

            return Ok(result);
        }
    }
}
