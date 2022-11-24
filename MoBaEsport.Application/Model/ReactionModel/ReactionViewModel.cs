using MoBaEsport.Data.EntityModel;
using MoBaEsport.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.ReactionModel
{
    public class ReactionViewModel
    { 
        public Reactions ReacName { get; set; }
        public DateTime Created { get; set; }
        public long CommentId { get; set; }
        public virtual Comment? comment { get; set; }

        public long PostId { get; set; }
        public virtual Post? post { get; set; }


        public Guid UserId { get; set; }
        public AppUser User { get; set; }
    }
}
