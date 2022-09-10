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
        Task<int> Create(ChatBoxCreateModel model);

        Task<int> Delete(long chatboxId);

        Task<MessageViewModel> GetMessage(Message messtoget);

        Task<List<MessageViewModel>> ViewListMessage(long chatboxid);

        Task<ChatBoxViewModel> ViewChatBox(long chatboxid);

        Task<int> SendMessage(Guid userid, MessageCreateModel model);
    }
}
