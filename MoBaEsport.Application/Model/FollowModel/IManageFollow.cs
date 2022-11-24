using MoBaEsport.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.FollowModel
{
    public interface IManageFollow
    {
        Task<bool> Create(FollowCreateModel model);

        Task<Follow> GetFollow(Guid targetId, Guid userId);

        Task<bool> Delete(long followId);
    }
}
