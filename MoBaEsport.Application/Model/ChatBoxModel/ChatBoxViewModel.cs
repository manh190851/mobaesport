using MoBaEsport.Application.Model.MessageModel;
using MoBaEsport.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.ChatBoxModel
{
    public class ChatBoxViewModel
    {
        public long chatboxId { get; set; }
        public List<MessageViewModel>? Messages { get; set; }

        public string color { get; set; }

        public long FriendId { get; set; }

        public virtual Friend FriendIdInChatBox { get; set; }
    }
}
