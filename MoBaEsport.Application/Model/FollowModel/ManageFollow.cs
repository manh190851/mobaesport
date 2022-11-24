using MoBaEsport.Data.DBContextModel;
using MoBaEsport.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.FollowModel
{
    public class ManageFollow : IManageFollow
    {
        private ESportDbContext db;

        public ManageFollow(ESportDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> Create(FollowCreateModel model)
        {
            var follow = new Follow()
            {
                FollowerId = model.FollowerId,
                FollowingId = model.FollowingId,
                Created = model.Created
            };

            db.Follows.Add(follow);
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(long followId) //Un follow
        {
            var follow = db.Follows.Find(followId);

            if (follow == null) throw new Exception();

            db.Follows.Remove(follow);

            await db.SaveChangesAsync();

            return true;
        }

        public async Task<Follow> GetFollow(Guid targetId, Guid userId)
        {
            var follow = db.Follows.ToList().Where(i => i.FollowerId == userId && i.FollowingId == targetId);
            if(follow == null) throw new Exception();

            var result = follow.First();

            return result;
        }
    }
}
