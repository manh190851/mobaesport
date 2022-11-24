namespace MoBaEsport.Application.Model.FollowModel
{
    public class FollowCreateModel
    {
        public Guid FollowerId { get; set; } // User who want to follow
        public Guid FollowingId { get; set; } // User who allow to follow
        public DateTime Created { get; set; }
    }
}