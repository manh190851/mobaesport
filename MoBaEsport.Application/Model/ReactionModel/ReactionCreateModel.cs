using MoBaEsport.Data.Enum;

namespace MoBaEsport.Application.Model.ReactionModel
{
    public class ReactionCreateModel
    {
        public long ReacId { get; set; }
        public Reactions ReacName { get; set; }
        public DateTime Created { get; set; }
        public long? PostId { get; set; }
        public long? ComId { get; set; }
        public Guid UserId { get; set; }
        public long? ReplyId { get; set; }
    }
}