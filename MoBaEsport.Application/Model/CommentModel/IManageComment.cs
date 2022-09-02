using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.CommentModel
{
    public interface IManageComment
    {
        Task<int> Create(Guid userId, CommentCreateModel model);

        Task<int> Update(Guid userId, CommentUpdateModel model, long commentId);

        Task<int> Delete(Guid userId, long commentId);
    }
}
