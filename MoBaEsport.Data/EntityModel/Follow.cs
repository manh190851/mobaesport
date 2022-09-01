using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Data.EntityModel
{
    public class Follow
    {
        public long FollowId { get; set; }
        public Guid FollowerId { get; set; } // User who want to follow
        public AppUser Follower { get; set; }
        public Guid FollowingId { get; set; } // User who allow to follow
        public AppUser Following { get; set; }
        public DateTime Created { get; set; }
    }
}
