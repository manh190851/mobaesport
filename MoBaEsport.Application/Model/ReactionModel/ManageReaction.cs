using MoBaEsport.Data.DBContextModel;
using MoBaEsport.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.ReactionModel
{
    public class ManageReaction : IManageReaction
    {
        private ESportDbContext db;
        public async Task<long> Create(ReactionCreateModel model)
        {
            var reaction = new Reaction()
            {
                ReacId = model.ReacId,
                ReacName = model.ReacName,
                Created = model.Created,
                ComId = model.ComId,
                PostId = model.PostId,
                UserId = model.UserId,
                ReplyId = model.ReplyId,
            };

            db.Reactions.Add(reaction);

            return await db.SaveChangesAsync();
        }

        public async Task<long> Delete(long reactionId)
        {
            var reaction = db.Reactions.Find(reactionId);
            db.Reactions.Remove(reaction);
            return await db.SaveChangesAsync();
        }

        public async Task<long> Update(ReactionUpdateModel model, long reactionId)
        {
            var reaction = db.Reactions.Find(reactionId);

            reaction.ReacName = model.ReacName;
            reaction.Created = model.Created;

            db.Reactions.Update(reaction);

            return await db.SaveChangesAsync();
        }
    }
}
