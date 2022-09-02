using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.PostModel
{
    public interface IPublicPost
    {
        Task<int> Create(Guid userId, PostCreateModel model);

        Task<int> Update(Guid userId, PostUpdateModel model, long PostId);

        Task<int> Delete(Guid userId, long PostId);

        Task<List<PostViewModel>> ViewPosts(Guid userId);
    }
}
