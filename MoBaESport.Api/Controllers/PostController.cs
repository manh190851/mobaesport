using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoBaEsport.Application.Model.PostModel;

namespace MoBaESport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPublicPost _publicPost;
        private readonly PublicPost _post;
        private readonly IManagePost _managePost;

        public PostController(IPublicPost publicPost, PublicPost post, IManagePost managePost)
        {
            _publicPost = publicPost;
            _post = post;
            _managePost = managePost;
        }

        [HttpGet]
        public async Task<IActionResult> ViewPost(Guid userId)
        {
            var posts = await _publicPost.ViewPostsByUserId(userId);

            if (posts == null) return NotFound("Can not find!!");

            return Ok(posts.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]PostCreateModel model)
        {
            var post = await _publicPost.Create(model);

            if (post == 0) return BadRequest();

            return CreatedAtAction(nameof(ViewPost), post);
        }

        //[HttpPut("{postId}")]
        /*public async Task<IActionResult> Update(long postId,[FromForm]PostUpdateModel model)
        {
            var post = await _publicPost.Update();
        }*/
    } 
}
