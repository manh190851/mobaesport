using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.CommentModel
{
    public class ManageComment : IManageComment
    {
        public Task<int> Create(Guid userId, CommentCreateModel model)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Guid userId, long commentId)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Guid userId, CommentUpdateModel model, long commentId)
        {
            throw new NotImplementedException();
        }
    }
}
