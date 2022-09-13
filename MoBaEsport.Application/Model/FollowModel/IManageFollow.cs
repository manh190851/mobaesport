using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.FollowModel
{
    public interface IManageFollow
    {
        Task<long> Create(FollowCreateModel model);

        Task<long> Delete(Guid userId, long followId);
    }
}
