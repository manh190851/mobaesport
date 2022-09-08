using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.FollowModel
{
    public interface IManageFollow
    {
        Task<int> Create(FollowCreateModel model);

        Task<int> Delete(Guid userId, long followId);
    }
}
