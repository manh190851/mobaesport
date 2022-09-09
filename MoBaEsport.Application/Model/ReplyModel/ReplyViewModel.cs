using MoBaEsport.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.ReplyModel
{
    public class ReplyViewModel
    {
        public long ReplyId { get; set; }
        public string ReplyContent { get; set; }
        public DateTime Created { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public List<Reaction>? Reactions { get; set; }
    }
}
