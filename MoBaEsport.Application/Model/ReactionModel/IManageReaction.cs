using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.ReactionModel
{
    public interface IManageReaction
    {
        Task<int> Create(ReactionCreateModel model);

        Task<int> Update(ReactionUpdateModel model, long reactionId);

        Task<int> Delete(long reactionId);
    }
}
