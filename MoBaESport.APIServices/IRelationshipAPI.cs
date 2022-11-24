using MoBaEsport.Application.Model.FollowModel;
using MoBaEsport.Application.Model.FriendModel;
using MoBaEsport.Application.Systems.UserServiceModel;
using MoBaEsport.Data.EntityModel;

namespace MoBaEsport.APIServices
{
    public interface IRelationshipAPI
    {
        //Follow
        Task<bool> CreateFollow(FollowCreateModel model, string token);
        Task<bool> DeleteFollow(long followId, string token);
        Task<Follow> FindFollow(Guid targetId, Guid userId, string token);
        Task<List<UserViewModel>> GetFollowingList(Guid userId, string token);
        Task<List<UserViewModel>> GetFollowerList(Guid userId, string token);


        //Friend
        Task<bool> CreateFriend(FriendCreateModel model, string token);
        Task<List<FriendRequestModel>> GetFriendRequest(Guid userId, string token);
        Task<bool> ConfirmRequest(long friendId, string token);
        Task<bool> DeleteRequest(long friendId, string token);
        Task<List<FriendViewModel>> GetFriendList(Guid userId, string token);
        Task<Friend> GetFriend(Guid userId, Guid targetId);
    }
}
