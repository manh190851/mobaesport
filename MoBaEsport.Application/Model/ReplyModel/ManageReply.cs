using MoBaEsport.Application.Model.ReactionModel;
using MoBaEsport.Data.DBContextModel;
using MoBaEsport.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.ReplyModel
{
    public class ManageReply : IManageReply
    {
        private ESportDbContext db;

        public ManageReply(ESportDbContext db)
        {
            this.db = db;
        }

        public async Task<long> Create(ReplyCreateModel model)
        {
            var reply = new Reply()
            {
                ReplyId = model.ReplyId,
                ReplyContent = model.ReplyContent,
                Created = model.Created,
                ComId = model.ComId,
                UserId = model.UserId,
            };

            db.Replies.Add(reply);

            return await db.SaveChangesAsync();
        }

        public async Task<long> Delete(Guid userId, long replyId)
        {
            var reply = db.Replies.Find(replyId);

            if (reply == null) throw new Exception("Cannot Find!!");

            if (reply.UserId != userId) throw new Exception("You cannot remove other's reply");

            db.Replies.Remove(reply);

            return await db.SaveChangesAsync();
        }

        public Task<ReactionViewModel> GetReaction(Reaction reactoget)
        {
            throw new NotImplementedException();
        }

        public async Task<long> Update(ReplyUpdateModel model, long replyId)
        {
            var reply = db.Replies.Find(replyId);

            if (reply == null) throw new Exception("Cannot find!!");

            reply.ReplyContent = model.ReplyContent;
            reply.Created = model.Created;

            db.Replies.Update(reply);

            return await db.SaveChangesAsync();
        }

        public Task<List<ReactionViewModel>> ViewListReaction(long replyId)
        {
            throw new NotImplementedException();
        }
    }
}
