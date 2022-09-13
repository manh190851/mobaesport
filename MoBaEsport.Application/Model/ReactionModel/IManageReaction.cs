using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.ReactionModel
{
    public interface IManageReaction
    {
        Task<long> Create(ReactionCreateModel model);

        Task<long> Update(ReactionUpdateModel model, long reactionId);

        Task<long> Delete(long reactionId);
    }
}
