using Microsoft.AspNetCore.Http;
using MoBaEsport.Data.Enum;

namespace MoBaEsport.Application.Model.PostModel
{
    public class PostUpdateModel
    {
        public string PostContent { get; set; }
        public DateTime Created { get; set; }
        public PostStatus Status { get; set; }
        public IFormFile postFile { get; set; }
    }
}