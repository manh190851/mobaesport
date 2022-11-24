using Microsoft.Extensions.Configuration;
using MoBaEsport.Application.Model.CommentModel;
using MoBaEsport.Application.Model.ReactionModel;
using MoBaEsport.Application.Model.ReplyModel;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MoBaEsport.APIServices
{
    public class CommentAPI : ICommentAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public CommentAPI(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<bool> CreateComment(CommentCreateModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.PostAsync($"/api/Comments/create-comment", httpContent);
            if (response.IsSuccessStatusCode) return true;

            return false;
        }

        public async Task<bool> DeleteComment(long commentId)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.DeleteAsync($"/api/Comments/delete-comment/?commentId={commentId}");
            if (response.IsSuccessStatusCode) return true;

            return false;
        }

        public async Task<List<ReactionViewModel>> GetReaction(long commentId)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync($"/api/Comments/view-comment-reaction/?commentId={commentId}");
            var body = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ReactionViewModel>>(body);

            return result;
        }

        public async Task<List<ReplyViewModel>> GetReply(long commentId)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync($"/api/Comments/view-reply/?commentId={commentId}");
            var body = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ReplyViewModel>>(body);

            return result;
        }

        public async Task<bool> UpdateComment(CommentUpdateModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.PostAsync($"/api/Comments/update-comment", httpContent);
            if (response.IsSuccessStatusCode) return true;

            return false;
        }
    }
}
