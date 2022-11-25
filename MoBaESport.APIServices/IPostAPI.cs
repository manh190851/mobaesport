using MoBaEsport.Application.Model.CommentModel;
using MoBaEsport.Application.Model.PostModel;
using MoBaEsport.Application.Model.ReactionModel;
using MoBaEsport.Data.Enum;

namespace MoBaEsport.APIServices
{
    public interface IPostAPI
    {
        //admin
        Task<List<PostReportModel>> GetReportPost();

        Task<bool> ManagePost(PostManageModel model);

        //user
        Task<bool> CreatePost(PostCreateModel model);

        Task<bool> UpdatePost(PostUpdateModel model);

        Task<bool> DeletePost(long postId);

        Task<List<PostViewModel>> GetPostsById(Guid userId);

        Task<List<CommentViewModel>> GetPostComment(long postId);

        Task<List<ReactionViewModel>> GetPostReaction(long postId);

        Task<bool> ChangeStatus(PostUpdateModel model);

        Task<bool> CreatePostRport(PostReportModel model);

        Task<bool> Share(PostCreateModel model);

        Task<long> CountPost();

    }
}
