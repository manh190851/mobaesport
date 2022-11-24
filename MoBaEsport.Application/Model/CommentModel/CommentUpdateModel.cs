namespace MoBaEsport.Application.Model.CommentModel
{
    public class CommentUpdateModel
    {
        public long commentId { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
    }
}