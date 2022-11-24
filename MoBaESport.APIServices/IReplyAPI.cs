using MoBaEsport.Application.Model.ReactionModel;
using MoBaEsport.Application.Model.ReplyModel;

namespace MoBaEsport.APIServices
{
    public interface IReplyAPI
    {
        Task<bool> CreateReply(ReplyCreateModel model);

        Task<bool> UpdateReply(ReplyUpdateModel model);

        Task<bool> Delete(long replyId);

        Task<ReplyViewModel> GetReply(long replyId);
    }
}
