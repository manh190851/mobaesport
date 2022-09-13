using MoBaEsport.Application.Model.MessageModel;
using MoBaEsport.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.ChatBoxModel
{
    public interface IManageChatBox
    {
        Task<long> Create(ChatBoxCreateModel model);

        Task<long> Delete(long chatboxId);

        Task<MessageViewModel> GetMessage(long messageId);

        Task<List<MessageViewModel>> GetListMessage(long chatboxid);

        Task<ChatBoxViewModel> ViewChatBox(long chatboxid);

        Task<long> ChangeColor(long chatboxId);
    }
}
