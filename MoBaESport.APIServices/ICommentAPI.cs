using MoBaEsport.Application.Model.CommentModel;
using MoBaEsport.Application.Model.ReactionModel;
using MoBaEsport.Application.Model.ReplyModel;

namespace MoBaEsport.APIServices
{
    public interface ICommentAPI
    {
        Task<bool> CreateComment(CommentCreateModel model);

        Task<bool> UpdateComment(CommentUpdateModel model);

        Task<bool> DeleteComment(long commentId);

        Task<List<ReactionViewModel>> GetReaction(long commentId);
        
        Task<List<ReplyViewModel>> GetReply(long commentId);


    }
}
