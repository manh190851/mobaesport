using MoBaEsport.Data.EntityModel;

namespace MoBaEsport.Application.Model.PostModel
{
    public class PostViewModel
    {
        public string PostContent { get; set; }
        public DateTime Created { get; set; }
        public long ShareCount { get; set; }
        public long? SharePostId { get; set; }
        public Post? SharePost { get; set; }
        public List<Reaction>? Reactions { get; set; }
        public List<Comment>? Comments { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
    }
}