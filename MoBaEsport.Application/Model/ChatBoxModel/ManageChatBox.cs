using MoBaEsport.Application.Model.MessageModel;
using MoBaEsport.Data.DBContextModel;
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
        private ESportDbContext db;

        public ManageChatBox(ESportDbContext context)
        {
            db = context;
        }

        public Task<long> ChangeColor(long chatboxId)
        {
            throw new NotImplementedException();
        }

        public async Task<long> Create(ChatBoxCreateModel model)
        {
            var chatbox = new ChatBox()
            {
                ChatBoxId = model.ChatBoxId,
                FriendId = model.friendId,
                ChatBoxColor = model.Color
            };

            db.ChatBox.Add(chatbox);

            return await db.SaveChangesAsync();
        }

        public async Task<long> Delete(long chatboxId)
        {
            var chatbox = db.ChatBox.Find(chatboxId);

            if (chatbox == null) throw new Exception("Not Found!");

            db.ChatBox.Remove(chatbox);

            return await db.SaveChangesAsync();
        }

        public async Task<MessageViewModel> GetMessage(long messageId)
        {
            var messtoget = db.Messages.Find(messageId);
            if (messtoget == null) throw new Exception("Not Found");

            MessageViewModel messageViewModel = new MessageViewModel()
            {
                Content = messtoget.Content,
                Created = messtoget.Created,
                ChatBoxId = messtoget.ChatBoxId,
                SenderId = messtoget.SenderId,
                Sender = messtoget.Sender,
                chatBox = messtoget.ChatBox
            };

            return messageViewModel;
        }

        public async Task<ChatBoxViewModel> ViewChatBox(long chatboxId)
        {
            var chatbox = db.ChatBox.Find(chatboxId);

            if (chatbox == null) throw new Exception();

            var chatboxViewModel = new ChatBoxViewModel()
            {
                FriendId = chatbox.FriendId,
                FriendIdInChatBox = chatbox.FriendIdInChatBox,
                Messages = await GetListMessage(chatbox.ChatBoxId),
                color = chatbox.ChatBoxColor
            };
            return chatboxViewModel;
        }

        public async Task<List<MessageViewModel>> GetListMessage(long chatboxid)
        {
            var listmessage = db.Messages.ToList().Where(m => m.ChatBoxId == chatboxid);

            if (listmessage == null) throw new Exception("Not Found");

            List<MessageViewModel> listViewMessage = new List<MessageViewModel>();

            foreach(var message in listmessage)
            {
                var messagetoget = await GetMessage(message.MessageId);
                listViewMessage.Add(messagetoget);
            }
            return listViewMessage;
        }
    }
}
