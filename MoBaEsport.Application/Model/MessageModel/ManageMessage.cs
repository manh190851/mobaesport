using MoBaEsport.Data.DBContextModel;
using MoBaEsport.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.MessageModel
{
    public class ManageMessage : IManageMessage
    {
        private ESportDbContext db;

        public ManageMessage(ESportDbContext db)
        {
            this.db = db;
        }

        public async Task<long> Create(MessageCreateModel model)
        {
            var message = new Message()
            {
                MessageId = model.MessageId,
                Content = model.Content,
                ChatBoxId = model.ChatBoxId,
                SenderId = model.SenderId,
                Created = model.Created,
            };

            db.Messages.Add(message);

            return await db.SaveChangesAsync();
        }

        public async Task<long> Delete(Guid userId, long messageId)
        {
            var message = db.Messages.Find(messageId);

            if (message == null) throw new Exception("Cannot Find!!");

            if (message.SenderId != userId) throw new Exception("You cannot remove other's message");

            db.Messages.Remove(message);

            return await db.SaveChangesAsync();
        }
    }
}
