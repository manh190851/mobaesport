using MoBaEsport.Data.Enum;

namespace MoBaEsport.Data.EntityModel
{
    public class Friend
    {
        public long FriendId { get; set; }
        public Guid RequestId { get; set; } //User who want to make friend with
        public AppUser RequestUser { get; set; }
        public Guid AcceptId { get; set; } // User who agree to make friend with
        public AppUser AcceptUser { get; set; }
        public FriendStatus Status { get; set; }
        public DateTime Created { get; set; }
    }
}