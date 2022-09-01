namespace MoBaEsport.Data.EntityModel
{
    public class Message
    {
        public long MessageId { get; set; }
        public Guid SenderId { get; set; }
        public AppUser Sender { get; set; }
        public string? Content { get; set; }
        public DateTime Created { get; set; }
        public long ChatBoxId { get; set; }
        public ChatBox ChatBox { get; set; }
    }
}