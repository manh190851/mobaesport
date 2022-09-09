using MoBaEsport.Application.Model.CommentModel;
using MoBaEsport.Application.Model.ReactionModel;
using MoBaEsport.Data.DBContextModel;
using MoBaEsport.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.PostModel
{
    public class PublicPost : IPublicPost
    {
        private ESportDbContext db;

        public PublicPost(ESportDbContext context)
        {
            this.db = context;
        }

        public async Task<int> Create(PostCreateModel model)
        {
            var post = new Post()
            {
                PostId = model.PostId,
                PostContent = model.PostContent,
                Created = model.Created,
                Status = model.Status,
                ShareCount = model.ShareCount,
                SharePostId = model.SharePostId,
                UserId = model.UserId
            };

            db.Posts.Add(post);
            
            return await db.SaveChangesAsync();
        }

        public async Task<int> Delete(Guid userId, long PostId)
        {
            var post = db.Posts.Find(PostId);

            if (post == null) throw new Exception("Can not Find!!");

            if (post.UserId != userId) throw new Exception("Can not delete other people's post!!");

            db.Posts.Remove(post);
            return await db.SaveChangesAsync();
        }

        public async Task<int> Update(Guid userId, PostUpdateModel model, long PostId)
        {
            var post = db.Posts.Find(PostId);

            if (post == null) throw new ArgumentNullException();

            post.PostContent = model.PostContent;
            post.Status = model.Status;
            post.Created = model.Created;

            return await db.SaveChangesAsync();
        }

        public Task<List<Post>> ViewPosts(Guid userId)
        {
           return (Task<List<Post>>)db.Posts.ToList().Where(m => m.UserId == userId);
        }

        public async Task<int> HiddenPost(long PostId)
        {
            var post = db.Posts.Find(PostId);

            post.IsHidden = true;

            return await db.SaveChangesAsync();
        }

        public Task<int> ReportPost(long PostId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> ShareCount(long postId)
        {
            var post = await db.Posts.FindAsync(postId);

            var shareposts = from sharepost in db.Posts
                             where sharepost.SharePostId == postId
                             select sharepost;

            post.ShareCount = shareposts.Count();

            return await db.SaveChangesAsync();
        }

        public Task<List<Comment>> ViewComment(long postId)
        {
            var comments = from comment in db.Comments
                           where comment.PostId == postId
                           select comment;

            return (Task<List<Comment>>)comments;
        }

        public Task<List<Reaction>> ViewReaction(long postId)
        {
            var reactions = from reaction in db.Reactions
                           where reaction.PostId == postId
                           select reaction;

            return (Task<List<Reaction>>)reactions;
        }

        public async Task<long> CountReaction(long PostId)
        {
            var post = db.Posts.Find(PostId);

            long reacCount = post.Reactions.Count();

            return reacCount;
        }

        public async Task<int> Get()
        {
            return 1;
        }
    }
}
