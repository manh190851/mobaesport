using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.ReactionModel
{
    public interface IManageReaction
    {
        Task<int> Create(Guid userId, ReactionCreateModel model);

        Task<int> Update(Guid userId, ReactionUpdateModel model, long reactionId);

        Task<int> Delete(Guid userId, long reactionId);
    }
}
