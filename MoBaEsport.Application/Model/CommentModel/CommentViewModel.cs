using MoBaEsport.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.CommentModel
{
    public class CommentViewModel
    {
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public long PostId { get; set; }
        public Post Post { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
    }
}
