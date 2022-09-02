using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.ReplyModel
{
    public class ManageReply : IManageReply
    {
        public Task<int> Create(Guid userId, ReplyCreateModel model)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Guid userId, long replyId)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Guid userId, ReplyUpdateModel model, long replyId)
        {
            throw new NotImplementedException();
        }
    }
}
