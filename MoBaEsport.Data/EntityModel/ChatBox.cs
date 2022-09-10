using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Data.EntityModel
{
    public class ChatBox
    {
        public long ChatBoxId { get; set; }
        public List<Message>? Messages { get; set; }
        public long FriendId { get; set; }
        public Friend FriendIdInChatBox { get; set; }
        public string ChatBoxColor { get; set; }
    }
}
