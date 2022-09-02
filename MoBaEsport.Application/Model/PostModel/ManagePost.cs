using MoBaEsport.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.PostModel
{
    public class ManagePost : IManagePost
    {
        public Task<int> Lock(long PostId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UnLock(long PostId)
        {
            throw new NotImplementedException();
        }

        public Task<List<PostReportModel>> ViewReportPost()
        {
            throw new NotImplementedException();
        }
    }
}
