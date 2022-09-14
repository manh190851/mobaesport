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
        private readonly IManagePost _managePost;

        public PostsController(IPublicPost publicPost, IManagePost managePost)
        {
            _publicPost = publicPost;
            _managePost = managePost;
        }

        [HttpGet("view-post-byuserId/{userId}")]
        public async Task<IActionResult> ViewPostByUserId(Guid userId)
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

        [HttpGet("view-post-comment/{postId}")]
        public async Task<IActionResult> ViewComment(long postId)
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

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]PostCreateModel model)
        {
            var postId = await _publicPost.Create(model);

            if (postId == 0) return BadRequest();

            var post = await _publicPost.GetPost(postId);

            return CreatedAtAction(nameof(ViewPostByUserId),new {userId = post.UserId }, post);
        }

        [HttpPut("{postId}")]
        public async Task<IActionResult> Update(long postId,[FromForm]PostUpdateModel model)
        {
            var post = await _publicPost.Update(postId, model);

            if(postId == 0) return BadRequest();

            return Ok("Update sucessfully");
        }

        [HttpDelete("{postId}")]
        public async Task<IActionResult> Delete(Guid userId, long postId)
        {
            var post = await _publicPost.Delete(userId, postId);

            if (postId == 0) return BadRequest();

            return Ok("Delete sucessfully");
        }

        [HttpPatch("hidden-post/{postId}")]
        public async Task<IActionResult> HiddenPost(long postId)
        {
            var post = await _publicPost.HiddenPost(postId);

            if (postId == 0) return BadRequest();

            return Ok("Sucessfully");
        }

        [HttpPatch("open-post/{postId}")]
        public async Task<IActionResult> OpenPost(long postId)
        {
            var post = await _publicPost.OpenPost(postId);

            if (postId == 0) return BadRequest();

            return Ok("Sucessfully");
        }

        [HttpPatch("report-post/{postId}")]
        public async Task<IActionResult> ReportPost(long postId)
        {
            var post = await _publicPost.ReportPost(postId);

            if (postId == 0) return BadRequest();

            return Ok("Sucessfully");
        }

        [HttpPatch("lock-post/{postId}")]
        public async Task<IActionResult> Lock(long postId)
        {
            var post = await _managePost.Lock(postId);

            if (post == 0) return BadRequest();

            return Ok(post);
        }

        [HttpPatch("unlock-post/{postId}")]
        public async Task<IActionResult> UnLock(long postId)
        {
            var post = await _managePost.UnLock(postId);

            if (post == 0) return BadRequest();

            return Ok();
        }

        [HttpGet("view-report-post/{postId}")]
        public async Task<IActionResult> ViewReportPost()
        {
            var posts = await _managePost.ViewReportPost();

            if (posts == null) return BadRequest();

            return Ok(posts);
        }
    } 
}
