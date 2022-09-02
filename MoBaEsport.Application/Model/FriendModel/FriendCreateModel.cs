using MoBaEsport.Data.Enum;

namespace MoBaEsport.Application.Model.FriendModel
{
    public class FriendCreateModel
    {
        public long FriendId { get; set; }
        public Guid RequestId { get; set; } //User who want to make friend with
        public Guid AcceptId { get; set; } // User who agree to make friend with
        public FriendStatus Status { get; set; }
        public DateTime Created { get; set; }
    }
}