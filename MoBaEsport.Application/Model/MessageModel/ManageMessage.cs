using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.MessageModel
{
    public class ManageMessage : IManageMessage
    {
        public Task<int> Create(Guid userId, MessageCreateModel model, long chatboxId)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Guid userId, long messageId)
        {
            throw new NotImplementedException();
        }
    }
}
