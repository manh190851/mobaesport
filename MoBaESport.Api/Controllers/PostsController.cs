using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoBaEsport.Application.Model.PostModel;

namespace MoBaESport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPublicPost _publicPost;

        public PostsController(IPublicPost publicPost)
        {
            _publicPost = publicPost;
        }

        [HttpGet("view-post-userId")]
        public async Task<IActionResult> ViewPostByUserId([FromQuery]Guid userId)
        {
            var actionResult = await _publicPost.ViewPostsByUserId(userId);

            if (actionResult == null) return NotFound("Can not find!!");

            return Ok(actionResult); //check after
        }

        [HttpGet("view-public-post")]
        public async Task<IActionResult> ViewPublicPost()
        {
            var listPost = await _publicPost.ViewPublicPost();

            if (listPost == null) return BadRequest(); 
            
            return Ok(listPost);
        }

        [HttpGet("view-post-comment")]
        public async Task<IActionResult> ViewComment([FromQuery] long postId)
        {
            var comments = await _publicPost.ViewComment(postId);

            if (comments == null) return BadRequest();

            return Ok(comments);
        }

        [HttpGet("view-post-reaction/{postId}")]
        public async Task<IActionResult> ViewReaction(long postId)
        {
            var reactions = await _publicPost.ViewReaction(postId);

            if (reactions == null) return BadRequest();

            return Ok(reactions);
        }

        [HttpPost("create-post")]
        public async Task<IActionResult> Create([FromForm]PostCreateModel model)
        {

            var postId = await _publicPost.Create(model);

            if (postId == -1) return BadRequest();

            return Ok(postId);
        }

        [HttpPut("update-post")]
        public async Task<IActionResult> Update([FromBody]PostUpdateModel model)
        {
            var post = await _publicPost.Update(model);

            if(post == 0) return BadRequest();

            return Ok("Update sucessfully");
        }

        [HttpDelete("delete-post")]
        public async Task<IActionResult> Delete([FromQuery] Guid userId, [FromQuery] long postId)
        {
            var post = await _publicPost.Delete(userId, postId);

            if (postId == 0) return BadRequest();

            return Ok("Delete sucessfully");
        }

        [HttpGet("view-report-post")]
        public async Task<IActionResult> ViewReportPost()
        {
            var posts = await _publicPost.ViewReportPost();

            if (posts == null) return BadRequest();

            return Ok(posts);
        }

        [HttpGet("count-post")]
        public async Task<IActionResult> CountPost()
        {
            long counter = await _publicPost.CountPost();
            return Ok(counter);
        }

        [HttpPut("share-post")]
        public async Task<IActionResult> SharePost([FromQuery] PostShareModel model)
        {
            var result = await _publicPost.Share(model);
            if(result == 0) return BadRequest();

            return Ok(result);
        }

        [HttpPut("change-status")]
        public async Task<IActionResult> ChangeStatus([FromBody] PostUpdateModel model)
        {
            var post = await _publicPost.GetPost(model.postId);
            if(post == null) return BadRequest();
            var result = await _publicPost.UpdateStatus(model);
            if(result == 0) return BadRequest();
            return Ok(result);
        }
    } 
}
