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

        public async Task<long> Delete(long commentId)
        {
            var comment = db.Comments.Find(commentId);

            if (comment == null) throw new ArgumentNullException("Cannot find");
            db.Comments.Remove(comment);

            return await db.SaveChangesAsync();
        }

        public async Task<List<ReplyViewModel>> GetReplies(long commentId)
        {
            if (commentId == null) throw new Exception("Not Found!!");

            List<ReplyViewModel> replyList = new List<ReplyViewModel>();
            var replies = db.Replies.ToList().Where(i => i.ComId == commentId);

            foreach(Reply reply in replies)
            {
                ReplyViewModel replyViewModel = new ReplyViewModel()
                {
                    ReplyContent = reply.ReplyContent,
                    Created = reply.Created,
                    UserId = reply.UserId,
                    CommentId = reply.ComId,
                };
                replyList.Add(replyViewModel);
            }
            
            return replyList;
        }

        public async Task<List<ReactionViewModel>> GetReaction(long commentId)
        {
            if (commentId == null) throw new Exception("Not Found!!");

            List<ReactionViewModel> reactionViews = new List<ReactionViewModel>();
            var reaction = db.Reactions.ToList().Where(i => i.ComId == commentId);

            foreach(Reaction reac in reaction)
            {
                ReactionViewModel reactionViewModel = new ReactionViewModel()
                {
                    ReacName = reac.ReacName,
                    Created = reac.Created,
                    UserId = reac.UserId,
                    CommentId = commentId,
                    comment = reac.Comment,
                };
                reactionViews.Add(reactionViewModel);
            }
            
            return reactionViews;
        }

        public async Task<long> Update(CommentUpdateModel model, long commentId)
        {
            var comment = db.Comments.Find(commentId);

            if (comment == null) throw new Exception("Cannot find!!");

            comment.Content = model.Content;
            comment.Created = model.Created;

            return await db.SaveChangesAsync();
        }
    }
}
