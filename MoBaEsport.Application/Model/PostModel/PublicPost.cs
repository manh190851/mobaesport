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

        public async Task<long> Create(PostCreateModel model)
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
            
            await db.SaveChangesAsync();

            return post.PostId;
        }

        public async Task<long> Delete(Guid userId, long PostId)
        {
            var post = db.Posts.Find(PostId);

            if (post == null) throw new Exception("Can not Find!!");

            if (post.UserId != userId) throw new Exception("Can not delete other people's post!!");

            db.Posts.Remove(post);
            return await db.SaveChangesAsync();
        }

        public async Task<long> Update(long PostId, PostUpdateModel model)
        {
            var post = db.Posts.Find(PostId);

            if (post == null) throw new ArgumentNullException();

            post.PostContent = model.PostContent;
            post.Status = model.Status;
            post.Created = model.Created;

            return await db.SaveChangesAsync();
        }

        public async Task<List<PostViewModel>> ViewPostsByUserId(Guid userId)
        {
            var posts = db.Posts.ToList().Where(m => m.UserId == userId);

            if (posts == null) throw new Exception(String.Format("Can not find any post with id:{0} ", userId));

            var postViewModels = new List<PostViewModel>();

            foreach(var post in posts)
            {
                var postModel = await GetPost(post.PostId);
                postViewModels.Add(postModel);
            }

            return postViewModels;
        }

        public async Task<long> HiddenPost(long PostId)
        {
            var post = db.Posts.Find(PostId);

            post.IsHidden = true;

            return await db.SaveChangesAsync();
        }

        public async Task<long> ReportPost(long postId)
        {
            var post = db.Posts.Find(postId);

            if (post == null) throw new Exception("Not Found");

            post.Status = Data.Enum.PostStatus.Reporting;

            return await db.SaveChangesAsync();
        }

        public async Task<long> ShareCount(long postId)
        {
            var post = await db.Posts.FindAsync(postId);

            var shareposts = from sharepost in db.Posts
                             where sharepost.SharePostId == postId
                             select sharepost;

            post.ShareCount = shareposts.Count();

            await db.SaveChangesAsync();

            return post.ShareCount;
        }

        public async Task<List<CommentViewModel>> ViewComment(long postId)
        {
            var comments = db.Comments.ToList().Where(m => m.PostId == postId);

            if (comments.Count() == 0) throw new Exception("Not Found!!");

            var listComment = new List<CommentViewModel>();

            foreach(var comment in comments)
            {
                var commentModel = await GetComment(comment.ComId);
                listComment.Add(commentModel);
            }
            return listComment;
        }

        public async Task<List<ReactionViewModel>> ViewReaction(long postId)
        {
            var reactions = db.Reactions.ToList().Where(m => m.PostId == postId);

            if (reactions.Count() == 0) throw new Exception("Not Found");

            var listReaction = new List<ReactionViewModel>();

            foreach(var reaction in reactions)
            {
                var reactionModel = await GetReaction(reaction.ReacId);
                listReaction.Add(reactionModel);
            }
            return listReaction;
        }

        public async Task<List<PostViewModel>> ViewPublicPost()
        {
            var posts = db.Posts.ToList().Where(m => m.IsHidden = false);

            if (posts.Count() == 0) throw new Exception("Not Found!!");

            var list = new List<PostViewModel>();

            foreach(var post in posts)
            {
                var postmodel = await GetPost(post.PostId);
                list.Add(postmodel);
            }
            return list;
        }

        public async Task<long> OpenPost(long postId)
        {
            throw new NotImplementedException();
        }

        public async Task<PostViewModel> GetPost(long postId)
        {
            var post = db.Posts.Find(postId);
            if (post == null) throw new ArgumentNullException(nameof(post));

            PostViewModel postViewModel = new PostViewModel()
            {
                PostContent = post.PostContent,
                Status = post.Status,
                Created = post.Created,
                ShareCount = await ShareCount(post.PostId),
                SharePostId = post.SharePostId,
                UserId = post.UserId,
            };

            return postViewModel;
        }

        public async Task<CommentViewModel> GetComment(long commentId)
        {
            var comment = db.Comments.Find(commentId);
            if (comment == null) throw new ArgumentNullException(nameof(comment));

            CommentViewModel commentViewModel = new CommentViewModel()
            {
                Content = comment.Content,
                Created = comment.Created,
                PostId = comment.PostId,
                UserId = comment.UserId
            };
            return commentViewModel;
        }

        public async Task<ReactionViewModel> GetReaction(long reactionId)
        {
            var reaction = db.Reactions.Find(reactionId);

            if (reaction == null) throw new ArgumentNullException(nameof(reaction));

            ReactionViewModel reactionViewModel = new ReactionViewModel()
            {
                ReacName = reaction.ReacName,
                Created = reaction.Created,
                UserId = reaction.UserId
            };

            return reactionViewModel;
        }

        public async Task<long> UpdateStatus(long postId, Data.Enum.PostStatus newStatus)
        {
            var post = db.Posts.Find(postId);
            Data.Enum.PostStatus k = newStatus;

            switch (k)
            {
                case (Data.Enum.PostStatus)0:
                    post.Status = Data.Enum.PostStatus.Public;
                    break;
                case (Data.Enum.PostStatus)1:
                    post.Status = Data.Enum.PostStatus.Private;
                    break;
            }

            return await db.SaveChangesAsync();
        }
    }
}
