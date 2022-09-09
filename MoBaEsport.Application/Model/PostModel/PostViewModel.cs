using MoBaEsport.Data.EntityModel;
using MoBaEsport.Data.Enum;

namespace MoBaEsport.Application.Model.PostModel
{
    public class PostViewModel
    {
        public string PostContent { get; set; }
        public DateTime Created { get; set; }
        public PostStatus Status { get; set; }  
        public long ShareCount { get; set; }
        public long? SharePostId { get; set; }
        public Post? SharePost { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
    }
}