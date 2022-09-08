using MoBaEsport.Data.DBContextModel;
using MoBaEsport.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Model.CommentModel
{
    public class ManageComment : IManageComment
    {
        private ESportDbContext db;

        public ManageComment(ESportDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(CommentCreateModel model)
        {
            var comment = new Comment()
            {
                ComId = model.ComId,
                Content = model.Content,
                Created = model.Created,
                PostId = model.PostId,
                UserId = model.UserId,
            };
            db.Comments.Add(comment);

            return await db.SaveChangesAsync();
        }

        public async Task<int> Delete(Guid userId, long commentId)
        {
            var comment = db.Comments.Find(commentId);

            if (comment == null) throw new ArgumentNullException("Cannot find");
            if (comment.UserId != userId)
            {
                throw new Exception("You cannot remove other's comment!!");
            }
            db.Comments.Remove(comment);

            return await db.SaveChangesAsync();
        }

        public async Task<int> Update(CommentUpdateModel model, long commentId)
        {
            var comment = db.Comments.Find(commentId);

            if (comment == null) throw new Exception("Cannot find!!");

            comment.Content = model.Content;
            comment.Created = model.Created;

            return await db.SaveChangesAsync();
        }
    }
}
