using MoBaEsport.Application.Model.ReactionModel;
using MoBaEsport.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.ReplyModel
{
    public interface IManageReply
    {
        Task<long> Create(ReplyCreateModel model);

        Task<long> Update(ReplyUpdateModel model, long replyId);

        Task<long> Delete(Guid userId, long replyId);
        Task<ReplyViewModel> GetReply(long replyId);
    }
}
