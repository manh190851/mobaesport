using Microsoft.AspNetCore.Http;
using MoBaEsport.Application.Model.CommentModel;
using MoBaEsport.Application.Model.ReactionModel;
using MoBaEsport.Data.DBContextModel;
using MoBaEsport.Data.EntityModel;
using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoBaEsport.Application.Systems.FileStorageService;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace MoBaEsport.Application.Model.PostModel
{
    public class PublicPost : IPublicPost
    {
        private ESportDbContext db;
        private IStorageService _storageService;

        public PublicPost(ESportDbContext context, IStorageService storageService)
        {
            this.db = context;
            this._storageService = storageService;
        }

        public async Task<long> Create(PostCreateModel model)
        {
            var post = new Post()
            {
                PostContent = model.PostContent,
                Created = model.Created,
                Status = model.Status,
                ShareCount = model.ShareCount,
                SharePostId = model.SharePostId,
                UserId = model.UserId,
            };

            if(model.postFiles != null)
            {
                post.PostFiles = new List<PostFile>()
                {
                    new PostFile()
                    {
                        FilePath = await this.SaveFile(model.postFiles),
                        Size = model.postFiles.Length,
                        DateCreate = DateTime.Now,
                        IsDefault = true
                    }
                };
            }

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

        public async Task<long> Update(PostUpdateModel model)
        {
            var post = db.Posts.Find(model.postId);

            if (post == null) throw new ArgumentNullException();

            post.PostContent = model.PostContent;
            post.Status = model.Status;
            post.Created = model.Created;

            if (model.postFiles != null)
            {
                var postFile = await db.PostFiles.FirstOrDefaultAsync(i => i.IsDefault == true && i.PostId == model.postId);
                postFile.FilePath = await this.SaveFile(model.postFiles);
                postFile.Size = model.postFiles.Length;
            }

            return await db.SaveChangesAsync();
        }

        public async Task<List<PostViewModel>> ViewPostsByUserId(Guid userId)
        {
            var posts = db.Posts.ToList().Where(m => m.UserId == userId);

            if (posts == null) throw new Exception(String.Format("Can not find any post with id:{0} ", userId));

            var postViewModels = new List<PostViewModel>();

            foreach(var post in posts)
            {
                PostViewModel postViewModel = new PostViewModel()
                {
                    PostContent = post.PostContent,
                    Status = post.Status,
                    Created = post.Created,
                    ShareCount = await ShareCount(post.PostId),
                    SharePostId = post.SharePostId,
                    UserId = userId,
                    User = await db.Users.FindAsync(userId),
                    Images = await this.GetPostImage(post.PostId),
                };
                postViewModels.Add(postViewModel);
            }

            return postViewModels;
        }

        public async Task<long> HiddenPost(long PostId)
        {
            var post = db.Posts.Find(PostId);

            post.IsHidden = true;

            return await db.SaveChangesAsync();
        }

        public async Task<List<PostViewModel>> ViewReportPost()
        {
            var listReport = db.Posts.ToList().Where(m => m.Status == Data.Enum.PostStatus.Reporting);

            List<PostViewModel> result = new List<PostViewModel>();

            foreach (var post in listReport)
            {
                PostViewModel postView = new PostViewModel()
                {
                    PostContent = post.PostContent,
                    Status = post.Status,
                    Created = post.Created,
                    ShareCount = await ShareCount(post.PostId),
                    SharePostId = post.SharePostId,
                    UserId = post.UserId,
                    Images = await this.GetPostImage(post.PostId)
                };
                result.Add(postView);
            }
            return result;
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
                PostViewModel postViewModel = new PostViewModel()
                {
                    PostContent = post.PostContent,
                    Status = post.Status,
                    Created = post.Created,
                    ShareCount = await ShareCount(post.PostId),
                    SharePostId = post.SharePostId,
                    UserId = post.UserId,
                    Images = await this.GetPostImage(post.PostId),
                };
                list.Add(postViewModel);
            }
            return list;
        }

        public async Task<IEnumerable<PostFile>>? GetPostImage(long postId)
        {
            var images = db.PostFiles.ToList().Where(i => i.PostId == postId);

            return images;
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

        public async Task<long> UpdateStatus(PostUpdateModel model)
        {
            var post = db.Posts.Find(model.postId);
            Data.Enum.PostStatus k = model.Status;

            switch (k)
            {
                case (Data.Enum.PostStatus)1:
                    post.Status = Data.Enum.PostStatus.Private;
                    break;
                case (Data.Enum.PostStatus)2:
                    post.Status = Data.Enum.PostStatus.Hidden;
                    break;
                case (Data.Enum.PostStatus)3:
                    post.Status = Data.Enum.PostStatus.Reporting;
                    break;
                case (Data.Enum.PostStatus)4:
                    post.Status = Data.Enum.PostStatus.Locked;
                    break;
                default:
                    post.Status = Data.Enum.PostStatus.Public;
                    break;
            }

            return await db.SaveChangesAsync();
        }

        public async Task<string> SaveFile(IFormFile file) 
        {
            var originalFilename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var filename = $"{Guid.NewGuid()}{Path.GetExtension(originalFilename)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), filename);
            return filename;
        }

        public async Task<long> CountPost()
        {
            long counter = db.Posts.LongCount();
            return counter;
        }

        public async Task<long> Share(PostShareModel model)
        {
            var post = db.Posts.Find(model.postId);
            if (post == null) throw new Exception("Not found postId");
            post.SharePostId = model.sharepostId;
            post.SharePost = await db.Posts.FindAsync(model.sharepostId);
            
            await db.SaveChangesAsync();
            return post.PostId;
        }

        public async Task<PostViewModel> GetPost(long postId)
        {
            var post = db.Posts.Find(postId);
            if (post == null) throw new ArgumentNullException();
            return new PostViewModel
            {
                PostId = post.PostId,
                PostContent = post.PostContent,
                Created = post.Created,
                ShareCount = post.ShareCount,
                SharePostId = post.SharePostId,
                Status = post.Status,
                Images = post.PostFiles,
                UserId = post.UserId,
            };
        }
    }
}
