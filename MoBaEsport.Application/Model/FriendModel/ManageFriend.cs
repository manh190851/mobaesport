using MoBaEsport.Data.DBContextModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.FriendModel
{
    public class ManageFriend : IManageFriend
    {
        private ESportDbContext db;

        public ManageFriend(ESportDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(Guid userId, FriendCreateModel model, Guid TargetId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(Guid userId, long friendId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FriendRequestModel>> ViewFriendRequest()
        {
            throw new NotImplementedException();
        }

        public async Task AcceptFriendRequest()
        {
            throw new NotImplementedException();
        }

        public async Task<FriendRequestModel> CreateRequest(Guid TargetId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FriendRequestModel>> ViewListRequest(Guid TargetId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AccepRequest(FriendRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}
