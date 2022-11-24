using MoBaEsport.Data.EntityModel;
using MoBaEsport.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.PostModel
{
    public class PostManageModel
    {
        public int postId { get; set; }

        public PostStatus postStatus { get; set; }
    }
}
