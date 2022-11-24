using MoBaEsport.Data.Enum;

namespace MoBaEsport.Data.EntityModel
{
    public class Post
    {
        public long PostId { get; set; }
        public string? PostContent { get; set; }
        public DateTime Created { get; set; }
        public PostStatus Status { get; set; }
        public bool IsHidden { get; set; }
        public long ShareCount { get; set; }
        public long? SharePostId { get; set; }
        public Post? SharePost { get; set; }
        public List<Reaction>? Reactions { get; set; }
        public List<Comment>? Comments { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public List<PostFile> PostFiles { get; set; }
    }
}