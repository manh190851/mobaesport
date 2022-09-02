namespace MoBaEsport.Application.Model.MessageModel
{
    public class MessageCreateModel
    {
        public long MessageId { get; set; }
        public Guid SenderId { get; set; }
        public string? Content { get; set; }
        public DateTime Created { get; set; }
        public long ChatBoxId { get; set; }
    }
}