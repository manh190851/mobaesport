using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.PostModel
{
    public interface IManagePost
    {
        Task<List<PostReportModel>> ViewReportPost();
        Task<int> Lock(long PostId);
        Task<int> UnLock(long PostId);
    }
}
