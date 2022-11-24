using MoBaEsport.Application.Model.ReactionModel;

namespace MoBaEsport.APIServices
{
    public interface IReactionAPI
    {
        Task<bool> CreateReaction(ReactionCreateModel model);

        Task<bool> UpdateReaction(ReactionUpdateModel model);

        Task<bool> DeleteReaction(long targetId);

        Task<ReactionViewModel> GetReactionById(long reacId);
    }
}
