using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.ReplyModel
{
    public interface IManageReply
    {
        Task<int> Create(Guid userId, ReplyCreateModel model);

        Task<int> Update(Guid userId, ReplyUpdateModel model, long replyId);

        Task<int> Delete(Guid userId, long replyId);
    }
}
