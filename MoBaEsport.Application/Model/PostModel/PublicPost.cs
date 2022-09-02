using MoBaEsport.Application.Model.CommentModel;
using MoBaEsport.Application.Model.ReactionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.PostModel
{
    public class PublicPost : IPublicPost
    {
        public Task<int> Create(Guid userId, PostCreateModel model)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Guid userId, long PostId)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Guid userId, PostUpdateModel model, long PostId)
        {
            throw new NotImplementedException();
        }

        public Task<List<PostViewModel>> ViewPosts(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HiddenPost(long PostId)
        {
            throw new NotImplementedException();
        }

        public Task<int> ReportPost(long PostId)
        {
            throw new NotImplementedException();
        }

        public Task<int> SharePost(long PostId, PostCreateModel model)
        {
            throw new NotImplementedException();
        }

        public Task<List<CommentViewModel>> ViewComment()
        {
            throw new NotImplementedException();
        }

        public Task<List<ReactionViewModel>> ViewReaction()
        {
            throw new NotImplementedException();
        }
    }
}
