namespace MoBaEsport.Data.EntityModel
{
    public class Comment
    {
        public long ComId { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public long PostId { get; set; }
        public Post Post { get; set; }
        public List<Reaction>? Reactions { get; set; }
        public List<Reply>? Replys { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
    }
}