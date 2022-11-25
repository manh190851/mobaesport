using Microsoft.Extensions.Configuration;
using MoBaEsport.Application.Model.CommentModel;
using MoBaEsport.Application.Model.PostModel;
using MoBaEsport.Application.Model.ReactionModel;
using MoBaEsport.Application.Systems.UserServiceModel;
using MoBaEsport.Data.EntityModel;
using MoBaEsport.Data.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;

namespace MoBaEsport.APIServices
{
    public class PostAPI : IPostAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public PostAPI(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<bool> ChangeStatus(PostUpdateModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.PutAsync($"api/Posts/change-status", httpContent);
            if (response.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<long> CountPost()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync($"/api/Posts/count-post");
            var body = await response.Content.ReadAsStringAsync();
            var counter = JsonConvert.DeserializeObject<long>(body);
            return counter;
        }

        public async Task<bool> CreatePost(PostCreateModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, Encoding.UTF8, "multipart/form-data");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.PostAsync($"/api/Posts/create-post", httpContent);
            if (!response.IsSuccessStatusCode) return false;
            return true;
        }

        public async Task<bool> DeletePost(long postId)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.DeleteAsync($"/api/Posts/delete-post/?postId={postId}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<List<CommentViewModel>> GetPostComment(long postId)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync($"/api/Posts/view-post-comment/?postId={postId}");
            var body = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<CommentViewModel>>(body);
            if (result == null) throw new ArgumentNullException();
            return result;
        }

        public async Task<List<ReactionViewModel>> GetPostReaction(long postId)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync($"/api/Posts/view-post-reaction/?postId={postId}");
            var body = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ReactionViewModel>>(body);
            if (result == null) throw new ArgumentNullException();
            return result;
        }

        public async Task<List<PostViewModel>> GetPostsById(Guid userId)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync($"/api/Posts/view-post-userId/?userId={userId}");
            var body = await response.Content.ReadAsStringAsync();
            var posts = JsonConvert.DeserializeObject<List<PostViewModel>>(body);

            return posts;
        }

        public async Task<List<PostReportModel>> GetReportPost()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync($"/api/Posts/view-report-post");
            var body = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<PostReportModel>>(body);
            return result;
        }

        public async Task<bool> ManagePost(PostManageModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.PutAsync($"/api/Posts/change-status", httpContent);
            if(response.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> CreatePostRport(PostReportModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.PutAsync($"/api/Posts/change-status", httpContent);
            if (response.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> Share(PostCreateModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.PutAsync($"/api/Posts/share-post", httpContent);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;

        }

        public async Task<bool> UpdatePost(PostUpdateModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.PutAsync($"/api/Posts/update-post", httpContent);
            if (!response.IsSuccessStatusCode) return false;

            return true;
        }
    }
}
