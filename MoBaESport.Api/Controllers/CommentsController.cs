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

        [HttpPost("create-comment")]
        public async Task<IActionResult> Create([FromBody]CommentCreateModel model)
        {
            var result = await _managecomment.Create(model);

            if (result == 0) return BadRequest();

            return Ok(result);
        }

        [HttpPut("update-comment")]
        public async Task<IActionResult> Update([FromBody]CommentUpdateModel model)
        {
            var result = await _managecomment.Update(model, model.commentId);

            if(result == 0) return BadRequest();

            return Ok(result);
        }

        [HttpDelete("delete-comment")]
        public async Task<IActionResult> Delete([FromQuery] long commentId)
        {
            var result = await _managecomment.Delete(commentId);

            if (result == 0) return BadRequest();

            return Ok(result);
        }

        [HttpGet("view-reply")]
        public async Task<IActionResult> ViewListReply([FromQuery] long commentId)
        {
            var result = await _managecomment.GetReplies(commentId);

            if(result == null) return BadRequest();

            return Ok(result);
        }

        [HttpGet("view-comment-reaction")]
        public async Task<IActionResult> ViewListReaction([FromQuery]long commentId)
        {
            var result = await _managecomment.GetReaction(commentId);

            if (result == null) return BadRequest();

            return Ok(result);
        }
    }
}
