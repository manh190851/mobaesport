using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.FriendModel
{
    public class ManageFriend : IManageFriend
    {
        public Task<int> Create(Guid userId, FriendCreateModel model, Guid TargetId)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Guid userId, long friendId)
        {
            throw new NotImplementedException();
        }

        public  Task SendFriendRequest (Guid userId, Guid TargetId) 
        { 
            throw new NotImplementedException(); 
        }

        public Task<List<FriendRequestModel>> ViewFriendRequest()
        {
            throw new NotImplementedException();
        }

        public Task AcceptFriendRequest()
        {
            throw new NotImplementedException();
        }
    }
}
