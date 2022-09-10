using MoBaEsport.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.MessageModel
{
    public class MessageViewModel
    {
        public Guid SenderId { get; set; }
        public virtual AppUser Sender { get; set; }
        public string? Content { get; set; }
        public DateTime Created { get; set; }
        public long ChatBoxId { get; set; }
        public virtual ChatBox chatBox { get; set; }
    }
}
