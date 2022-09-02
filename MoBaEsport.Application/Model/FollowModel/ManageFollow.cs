using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.FollowModel
{
    public class ManageFollow : IManageFollow
    {
        public Task<int> Create(Guid userId, FollowCreateModel model, Guid TargetId)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Guid userId, long followId)
        {
            throw new NotImplementedException();
        }
    }
}
