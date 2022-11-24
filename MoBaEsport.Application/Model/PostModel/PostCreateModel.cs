using Microsoft.AspNetCore.Http;
using MoBaEsport.Data.Enum;

namespace MoBaEsport.Application.Model.PostModel
{
    public class PostCreateModel
    {
        public string PostContent { get; set; }
        public DateTime Created { get; set; }
        public PostStatus Status { get; set; }
        public bool IsHidden { get; set; }
        public long ShareCount { get; set; }
        public long? SharePostId { get; set; }
        public Guid UserId { get; set; }
        public IFormFile postFiles { get; set; }
    }
}