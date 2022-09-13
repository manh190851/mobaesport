using MoBaEsport.Application.Model.CommentModel;
using MoBaEsport.Application.Model.ReactionModel;
using MoBaEsport.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.PostModel
{
    public interface IPublicPost
    {
        Task<long> Create(PostCreateModel model);

        Task<long> Update(long PostId, PostUpdateModel model);

        Task<long> Delete(Guid userId, long PostId);

        Task<List<PostViewModel>> ViewPostsByUserId(Guid userId);

        Task<List<PostViewModel>> ViewPublicPost();

        Task<long> HiddenPost(long postId);

        Task<long> OpenPost(long postId);

        Task<long> ReportPost(long postId);

        Task<long> UpdateStatus(long postId, Data.Enum.PostStatus newStatus);

        Task<List<CommentViewModel>> ViewComment(long postId);

        Task<List<ReactionViewModel>> ViewReaction(long postId);

        Task<PostViewModel> GetPost(long postId);

        Task<CommentViewModel> GetComment(long commentId);

        Task<ReactionViewModel> GetReaction(long reactionId);
    }
}
