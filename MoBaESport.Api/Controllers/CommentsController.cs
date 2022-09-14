using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoBaEsport.Application.Model.CommentModel;

namespace MoBaESport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IManageComment _managecomment;

        public CommentsController(IManageComment managecomment)
        {
            _managecomment = managecomment;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CommentCreateModel model)
        {
            var result = await _managecomment.Create(model);

            if (result == 0) return BadRequest();

            return Ok(result);
        }

        [HttpPut("{commentId}")]
        public async Task<IActionResult> Update([FromForm]CommentUpdateModel model, long commentId)
        {
            var result = await _managecomment.Update(model, commentId);

            if(result == 0) return BadRequest();

            return Ok(result);
        }

        [HttpDelete("{commentId}")]
        public async Task<IActionResult> Delete(Guid userid, long commentId)
        {
            var result = await _managecomment.Delete(userid, commentId);

            if (result == 0) return BadRequest();

            return Ok(result);
        }

        [HttpGet("view-reply/{commentId}")]
        public async Task<IActionResult> ViewListReply(long commentId)
        {
            var result = await _managecomment.ViewListReply(commentId);

            if(result == null) return BadRequest();

            return Ok(result);
        }

        [HttpGet("view-comment-reaction/{commentId}")]
        public async Task<IActionResult> ViewListReaction(long commentId)
        {
            var result = await _managecomment.ViewListReaction(commentId);

            if (result == null) return BadRequest();

            return Ok(result);
        }
    }
}
