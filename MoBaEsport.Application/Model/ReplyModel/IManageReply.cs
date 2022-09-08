using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.ReplyModel
{
    public interface IManageReply
    {
        Task<int> Create(ReplyCreateModel model);

        Task<int> Update(ReplyUpdateModel model, long replyId);

        Task<int> Delete(Guid userId, long replyId);
    }
}
