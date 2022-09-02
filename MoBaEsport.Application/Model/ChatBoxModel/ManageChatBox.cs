using MoBaEsport.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.ChatBoxModel
{
    public class ManageChatBox : IManageChatBox
    {
        public Task<int> Create(Guid userId, ChatBoxCreateModel model, Guid TargetId)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Guid userId, long ChatBoxId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Message>> Index()
        {
            throw new NotImplementedException();
        }
    }
}
