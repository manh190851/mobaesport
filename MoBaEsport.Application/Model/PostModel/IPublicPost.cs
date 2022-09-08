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
        Task<int> Create(PostCreateModel model);

        Task<int> Update(Guid userId, PostUpdateModel model, long PostId);

        Task<int> Delete(Guid userId, long PostId);

        Task<List<Post>> ViewPosts(Guid userId);
    }
}
