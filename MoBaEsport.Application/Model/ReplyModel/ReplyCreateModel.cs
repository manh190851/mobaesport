namespace MoBaEsport.Application.Model.ReplyModel
{
    public class ReplyCreateModel
    {
        public long ReplyId { get; set; }
        public string ReplyContent { get; set; }
        public DateTime Created { get; set; }
        public long ComId { get; set; }
        public Guid UserId { get; set; }
    }
}