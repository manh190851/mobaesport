using MoBaEsport.Data.Enum;

namespace MoBaEsport.Data.EntityModel
{
    public class Friend
    {
        public long FriendId { get; set; }
        public Guid RequestId { get; set; }
        public AppUser RequestUser { get; set; }
        public Guid AcceptId { get; set; }
        public AppUser AcceptUser { get; set; }
        public FriendStatus Status { get; set; }
        public DateTime Created { get; set; }
    }
}