using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.ChatBoxModel
{
    public interface IManageChatBox
    {
        Task<int> Create(Guid userId, ChatBoxCreateModel model, Guid TargetId);

        Task<int> Delete(Guid userId, long ChatBoxId);
    }
}
