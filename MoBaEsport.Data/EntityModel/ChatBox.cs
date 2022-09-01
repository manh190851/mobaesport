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
        public Guid OwnerId { get; set; }
        public AppUser BoxOwner { get; set; }
        public Guid ChatWithId { get; set; }
        public AppUser ChatWithUser { get; set; }
    }
}
