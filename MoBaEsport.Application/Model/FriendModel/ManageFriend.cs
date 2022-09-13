using MoBaEsport.Data.DBContextModel;
using MoBaEsport.Data.EntityModel;
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

        public async Task<long> Delete(Guid userId, long friendId)
        {
            var friend = db.Friends.Find(friendId);

            if (friend == null) throw new Exception();
            if(friend.RequestId != userId && friend.AcceptId != userId) throw new Exception();

            db.Friends.Remove(friend);

            return await db.SaveChangesAsync();
        }

        public async Task<long> CreateRequest(FriendCreateModel model)
        {
            var friendRequest = new Friend()
            {
                FriendId = model.FriendId,
                AcceptId = model.AcceptId,
                Created = model.Created,
                RequestId = model.RequestId,
                Status = Data.Enum.FriendStatus.Requesting
            };
            db.Friends.Add(friendRequest);

            return await db.SaveChangesAsync();
        }

        public async Task<long> AccepRequest(long friendId)
        {
            var friend = db.Friends.Find(friendId);

            if (friend == null) throw new Exception();
            if (friend.Status != Data.Enum.FriendStatus.Requesting) throw new Exception();

            friend.Status = Data.Enum.FriendStatus.Friend;

            return await db.SaveChangesAsync();
        }
    }
}
