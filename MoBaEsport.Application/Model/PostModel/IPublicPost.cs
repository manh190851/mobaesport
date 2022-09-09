﻿using MoBaEsport.Application.Model.CommentModel;
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
        Task<int> Create(PostCreateModel model);

        Task<int> Update(PostUpdateModel model, long PostId);

        Task<int> Delete(Guid userId, long PostId);

        Task<List<PostViewModel>> ViewPostsByUserId(Guid userId);

        Task<List<PostViewModel>> ViewPublicPost();

        Task<int> HiddenPost(long postId);

        Task<int> OpenPost(long postId);

        Task<PostViewModel> GetReportPost(long postId);

        Task<List<CommentViewModel>> ViewComment(long postId);

        Task<List<ReactionViewModel>> ViewReaction(long postId);

        Task<PostViewModel> GetPost(Post post);

        Task<CommentViewModel> GetComment(Comment comment);

        Task<ReactionViewModel> GetReaction(Reaction reaction);
    }
}
