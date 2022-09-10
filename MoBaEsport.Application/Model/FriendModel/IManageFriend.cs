using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.FriendModel
{
    public interface IManageFriend
    {
        Task<int> Create(Guid userId, FriendCreateModel model, Guid TargetId);

        Task<FriendRequestModel> CreateRequest(Guid TargetId);

        Task<int> Delete(Guid userId, long friendId);

        Task<List<FriendRequestModel>> ViewListRequest(Guid TargetId);

        Task<bool> AccepRequest(FriendRequestModel model);
    }
}
