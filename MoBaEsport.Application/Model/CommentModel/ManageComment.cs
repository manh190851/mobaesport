using MoBaEsport.Application.Model.ReactionModel;
using MoBaEsport.Application.Model.ReplyModel;
using MoBaEsport.Data.DBContextModel;
using MoBaEsport.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.CommentModel
{
    public class ManageComment : IManageComment
    {
        private ESportDbContext db;

        public ManageComment(ESportDbContext db)
        {
            this.db = db;
        }

        public async Task<long> Create(CommentCreateModel model)
        {
            var comment = new Comment()
            {
                ComId = model.ComId,
                Content = model.Content,
                Created = model.Created,
                PostId = model.PostId,
                UserId = model.UserId,
            };
            db.Comments.Add(comment);

            return await db.SaveChangesAsync();
        }

        public async Task<long> Delete(Guid userId, long commentId)
        {
            var comment = db.Comments.Find(commentId);

            if (comment == null) throw new ArgumentNullException("Cannot find");
            if (comment.UserId != userId)
            {
                throw new Exception("You cannot remove other's comment!!");
            }
            db.Comments.Remove(comment);

            return await db.SaveChangesAsync();
        }

        public Task<ReactionViewModel> GetReaction(Reaction reactoget)
        {
            throw new NotImplementedException();
        }

        public async Task<ReplyViewModel> GetReply(Reply replytoget)
        {
            if (replytoget == null) throw new Exception("Not Found!!");

            ReplyViewModel replyViewModel = new ReplyViewModel()
            {
                ReplyContent = replytoget.ReplyContent,
                Created = replytoget.Created,
                UserId = replytoget.UserId,
                CommentId = replytoget.ComId,
            };
            return replyViewModel;
        }

        public async Task<long> Update(CommentUpdateModel model, long commentId)
        {
            var comment = db.Comments.Find(commentId);

            if (comment == null) throw new Exception("Cannot find!!");

            comment.Content = model.Content;
            comment.Created = model.Created;

            return await db.SaveChangesAsync();
        }

        public Task<List<ReactionViewModel>> ViewListReaction(long commentId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ReplyViewModel>> ViewListReply(long commentId)
        {
            var replies = db.Replies.ToList().Where(m => m.ComId == commentId);

            var listviewreply = new List<ReplyViewModel>();

            foreach(var reply in replies)
            {
                var replyViewModel = await GetReply(reply);
                listviewreply.Add(replyViewModel);
            };
            return listviewreply;
        }
    }
}
