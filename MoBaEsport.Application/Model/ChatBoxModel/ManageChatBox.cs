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
            this.db = context;
        }

        public async Task<int> Create(ChatBoxCreateModel model)
        {
            var chatbox = new ChatBox()
            {
                ChatBoxId = model.ChatBoxId,
                OwnerId = model.OwnerId,
                ChatWithId = model.ChatWithId
            };

            db.ChatBox.Add(chatbox);

            return await db.SaveChangesAsync();
        }

        public Task<int> Delete(long chatboxId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Message>> GetMessages(long chatboxId)
        {
            var messageList = from message in db.Messages
                              where message.ChatBoxId == chatboxId
                              select message;
            return (Task<List<Message>>)messageList;
        }
    }
}
