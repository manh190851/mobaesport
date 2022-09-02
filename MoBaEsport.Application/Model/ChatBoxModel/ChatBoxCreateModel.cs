namespace MoBaEsport.Application.Model.ChatBoxModel
{
    public class ChatBoxCreateModel
    {
        public long ChatBoxId { get; set; }
        public Guid OwnerId { get; set; }
        public Guid ChatWithId { get; set; }
    }
}