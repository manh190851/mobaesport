using MoBaEsport.Data.DBContextModel;
using MoBaEsport.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.PostModel
{
    public class ManagePost : IManagePost
    {
        private ESportDbContext _db;

        public ManagePost(ESportDbContext db)
        {
           this._db = db;
        }

        public async Task Lock(long postId)
        {
            var post = _db.Posts.Find(postId);

            post.Status = Data.Enum.PostStatus.Locked;

            await _db.SaveChangesAsync();
        }

        public async Task UnLock(long PostId)
        {
            var posts = _db.Posts.Find(PostId);

            if (posts.Status != Data.Enum.PostStatus.Locked) throw new Exception("Wrong access!!");

            posts.Status = Data.Enum.PostStatus.Public;

            await _db.SaveChangesAsync();
        }

        public async Task<List<PostViewModel>> ViewReportPost()
        {
            var listReport = _db.Posts.ToList().Where(m => m.Status == Data.Enum.PostStatus.Reporting);

            List<PostViewModel> result = new List<PostViewModel>();

            foreach(var post in listReport)
            {
                var postView = await GetPost(post);
                result.Add(postView);
            }

            return result;
        }

        public async Task<PostViewModel> GetPost(Post post)
        {
            if (post == null) throw new ArgumentNullException(nameof(post));

            PostViewModel postViewModel = new PostViewModel()
            {
                PostContent = post.PostContent,
                Status = post.Status,
                Created = post.Created,
                ShareCount = post.ShareCount,
                SharePostId = post.SharePostId,
                UserId = post.UserId,
            };

            return postViewModel;
        }
    }
}
