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

        public async Task<int> Create(FollowCreateModel model)
        {
            var follow = new Follow()
            {
                FollowId = model.FollowId,
                FollowerId = model.FollowerId,
                FollowingId = model.FollowingId,
                Created = model.Created
            };

            db.Follows.Add(follow);

            return await db.SaveChangesAsync();
        }

        public async Task<int> Delete(Guid userId, long followId) //Un follow
        {
            var follow = db.Follows.Find(followId);

            if (follow == null) throw new Exception();

            if (follow.FollowerId != userId) throw new Exception();

            db.Follows.Remove(follow);

            return await db.SaveChangesAsync();
        }
    }
}
