using MoBaEsport.Data.EntityModel;
using MoBaEsport.Data.Enum;

namespace MoBaEsport.Application.Model.PostModel
{
    public class PostViewModel
    {
        public long PostId { get; set; }
        public string PostContent { get; set; }
        public DateTime Created { get; set; }
        public PostStatus Status { get; set; }  
        public long ShareCount { get; set; }
        public long? SharePostId { get; set; }
        public virtual Post? SharePost { get; set; }
        public IEnumerable<PostFile>? Images { get; set; }
        public Guid UserId { get; set; }
        public virtual AppUser User { get; set; }
    }
}