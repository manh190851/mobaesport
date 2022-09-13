using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.PostModel
{
    public interface IManagePost
    {
        Task<List<PostViewModel>> ViewReportPost();
        Task<long> Lock(long PostId);
        Task<long> UnLock(long PostId);
    }
}
