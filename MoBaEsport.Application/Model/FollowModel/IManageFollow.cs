using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.FollowModel
{
    public interface IManageFollow
    {
        Task<int> Create(Guid userId, FollowCreateModel model, Guid TargetId);

        Task<int> Delete(Guid userId, long followId);
    }
}
