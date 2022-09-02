using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.ReactionModel
{
    public class ManageReaction : IManageReaction
    {
        public Task<int> Create(Guid userId, ReactionCreateModel model)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Guid userId, long reactionId)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Guid userId, ReactionUpdateModel model, long reactionId)
        {
            throw new NotImplementedException();
        }

        public Task CheckObjectReaction(Guid userId, long PostId, long CommentId, long ReplyId)
        {
            return Task.CompletedTask;
        }
    }
}
