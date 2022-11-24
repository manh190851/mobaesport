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
        Task<long> Update(PostUpdateModel model);
        Task<long> Delete(Guid userId, long PostId);
        Task<List<PostViewModel>> ViewPostsByUserId(Guid userId);
        Task<List<PostViewModel>> ViewPublicPost();
        Task<long> HiddenPost(long postId);
        Task<List<PostViewModel>> ViewReportPost();
        Task<long> UpdateStatus(PostUpdateModel model);
        Task<List<CommentViewModel>> ViewComment(long postId);
        Task<List<ReactionViewModel>> ViewReaction(long postId);
        Task<IEnumerable<PostFile>> GetPostImage(long postId);
        Task<CommentViewModel> GetComment(long commentId);
        Task<ReactionViewModel> GetReaction(long reactionId);
        Task<long> CountPost();
        Task<long> Share(PostShareModel model);
        Task<PostViewModel> GetPost(long postId);
    }
}
