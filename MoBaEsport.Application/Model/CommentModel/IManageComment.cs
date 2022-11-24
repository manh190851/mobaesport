using MoBaEsport.Application.Model.ReactionModel;
using MoBaEsport.Application.Model.ReplyModel;
using MoBaEsport.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.CommentModel
{
    public interface IManageComment
    {
        Task<long> Create(CommentCreateModel model);

        Task<long> Update(CommentUpdateModel model, long commentId);

        Task<long> Delete(long commentId);

        Task<List<ReplyViewModel>> GetReplies(long commentId);

        Task<List<ReactionViewModel>> GetReaction(long commentId);
    }
}
