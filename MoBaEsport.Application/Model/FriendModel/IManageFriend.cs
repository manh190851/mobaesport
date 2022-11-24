using MoBaEsport.Application.Systems.UserServiceModel;
using MoBaEsport.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.FriendModel
{
    public interface IManageFriend
    {
        Task<long> CreateRequest(FriendCreateModel model);

        Task<long> Delete(long friendId);

        Task<long> ConfirmRequest(long friendId);
        Task<List<FriendRequestModel>> GetFriendRequest(Guid userId);
        Task<List<FriendViewModel>> GetListFriend(Guid userId);
        Task<Friend> GetFriend(Guid userId, Guid targetId);
    }
}
