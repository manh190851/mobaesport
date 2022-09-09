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

        public PostController(IPublicPost publicPost)
        {
            _publicPost = publicPost;
        }

        public PostController(PublicPost post)
        {
            _post = post;
        }

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            return Ok("Fine");
        }
    } 
}
