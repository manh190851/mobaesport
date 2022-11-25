using MoBaEsport.Application.Systems.UserServiceModel;
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

        public async Task<long> Delete(long friendId)
        {
            var friend = db.Friends.Find(friendId);

            if (friend == null) throw new ArgumentNullException();

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
                Status = model.Status,
            };
            db.Friends.Add(friendRequest);

            return await db.SaveChangesAsync();
        }

        public async Task<long> ConfirmRequest(long friendId)
        {
            var friend = db.Friends.Find(friendId);

            if (friend == null) throw new ArgumentNullException();
            if (friend.Status != Data.Enum.FriendStatus.Requesting) throw new Exception();

            friend.Status = Data.Enum.FriendStatus.Friend;

            return await db.SaveChangesAsync();
        }

        public async Task<List<FriendRequestModel>> GetFriendRequest(Guid userId)
        {
            var requests = db.Friends.ToList().Where(i => i.AcceptId == userId && i.Status == Data.Enum.FriendStatus.Requesting);

            if (requests == null) throw new ArgumentNullException();

            List<FriendRequestModel> listResult = new List<FriendRequestModel>();
            foreach(var i in requests)
            {
                listResult.Add(new FriendRequestModel {
                    friendId = i.FriendId,
                    RequestId = i.RequestId,
                    Requester = await db.Users.FindAsync(i.RequestId),
                    Created = i.Created,
                });
            }

            return listResult;
        }

        public async Task<List<FriendViewModel>> GetListFriend(Guid userId)
        {
            var list = db.Friends.ToList().Where(m => (m.RequestId == userId || m.AcceptId == userId) && m.Status == Data.Enum.FriendStatus.Friend);
            if (list == null) throw new ArgumentNullException();

            List<FriendViewModel> listbyRequest = new List<FriendViewModel>();
            List<FriendViewModel> listbyAccept = new List<FriendViewModel>();
            List<FriendViewModel> result = new List<FriendViewModel>();

            foreach(var item in list)
            {
                if(item.RequestId == userId) {
                    listbyRequest.Add(new FriendViewModel
                    {
                        friendId = item.FriendId,
                        Id = item.AcceptId,
                        Friend = await db.Users.FindAsync(item.AcceptId)
                    });
                }
                if (item.AcceptId == userId) {
                    listbyAccept.Add(new FriendViewModel
                    {
                        friendId = item.FriendId,
                        Id = item.RequestId,
                        Friend = await db.Users.FindAsync(item.RequestId)
                    });
                }
            }

            result.AddRange(listbyAccept);
            result.AddRange(listbyRequest);

            return result;
        }

        public async Task<Friend> GetFriend(Guid userId, Guid targetId)
        {
            var friend = db.Friends.ToList().Where(i =>
            (i.RequestId == userId && i.AcceptId == targetId) ||
            (i.AcceptId == userId && i.RequestId == targetId)).First();
            if(friend == null) throw new ArgumentNullException();
            return friend;
        }
    }
}
