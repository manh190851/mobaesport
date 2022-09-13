using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.FriendModel
{
    public interface IManageFriend
    {
        Task<long> CreateRequest(FriendCreateModel model);

        Task<long> Delete(Guid userId, long friendId);

        Task<long> AccepRequest(long friendId);
    }
}
