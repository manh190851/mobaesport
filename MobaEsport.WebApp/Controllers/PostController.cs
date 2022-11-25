using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoBaEsport.APIServices;
using MoBaEsport.Application.Model.PostModel;
using MoBaEsport.Data.EntityModel;

namespace MobaEsport.WebApp.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostAPI _postApi;
        private readonly IConfiguration _configuration;

        public PostController(IPostAPI postApi, IConfiguration configuration)
        {
            _postApi = postApi;
            _configuration = configuration;
        }

        public async Task<IActionResult> GetPostById(Guid userId)
        {
            var posts = await _postApi.GetPostsById(userId);
            if(posts == null) { 
                ViewData["NoPost"] = "There is no post"; 
                return View();
            }
            return View(posts.ToList());
        }

        public async Task<IActionResult> CreatePost(Guid userId)
        {
            return View(new PostCreateModel()
            {
                UserId = userId,
                Created = DateTime.Now,
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _postApi.CreatePost(model);
            if (result != null) {
                ViewData["Not find"] = "Not find";
            }
            return View(model);
        }
    }
}
