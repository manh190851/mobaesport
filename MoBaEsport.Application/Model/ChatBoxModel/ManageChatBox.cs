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

        public async Task<int> Create(ChatBoxCreateModel model)
        {
            /*var chatbox = new ChatBox()
            {
                ChatBoxId = model.ChatBoxId,
                OwnerId = model.OwnerId,
                ChatWithId = model.ChatWithId
            };

            db.ChatBox.Add(chatbox);

            return await db.SaveChangesAsync();*/
            throw new NotImplementedException();
        }

        public async Task<int> Delete(long chatboxId)
        {
            var chatbox = db.ChatBox.Find(chatboxId);

            if (chatbox == null) throw new Exception("Not Found!");

            db.ChatBox.Remove(chatbox);

            return await db.SaveChangesAsync();
        }

        public async Task<MessageViewModel> GetMessage(Message messtoget)
        {
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

        public async Task<int> SendMessage(Guid userid, MessageCreateModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ChatBoxViewModel> ViewChatBox(long chatboxid)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MessageViewModel>> ViewListMessage(long chatboxid)
        {
            var listmessage = db.Messages.ToList().Where(m => m.ChatBoxId == chatboxid);

            if (listmessage == null) throw new Exception("Not Found");

            List<MessageViewModel> listViewMessage = new List<MessageViewModel>();

            foreach(var message in listmessage)
            {
                var messagetoget = await GetMessage(message);
                listViewMessage.Add(messagetoget);
            }
            return listViewMessage;
        }
    }
}
