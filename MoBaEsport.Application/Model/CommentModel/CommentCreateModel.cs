namespace MoBaEsport.Application.Model.CommentModel
{
    public class CommentCreateModel
    {
        public long ComId { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public long PostId { get; set; }
        public Guid UserId { get; set; }
    }
}