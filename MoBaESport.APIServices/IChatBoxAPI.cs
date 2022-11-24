using MoBaEsport.Application.Model.ChatBoxModel;
using MoBaEsport.Application.Model.MessageModel;

namespace MoBaEsport.APIServices
{
    public interface IChatBoxAPI
    {
        Task<bool> CreateChatBox(ChatBoxCreateModel model);
        Task<bool> CreateMessage(MessageCreateModel model);

        Task<bool> DeleteMessage(long messageId);

        Task<List<MessageViewModel>> GetMessages(long chatboxId);

        Task<ChatBoxViewModel> GetChatBox(long chatboxId);
    }
}
