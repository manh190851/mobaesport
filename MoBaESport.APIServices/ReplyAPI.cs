using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MoBaEsport.Application.Model.ReactionModel;
using MoBaEsport.Application.Model.ReplyModel;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MoBaEsport.APIServices
{
    public class ReplyAPI : IReplyAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ReplyAPI(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<bool> CreateReply(ReplyCreateModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.PostAsync($"api/Replies/create-reply", httpContent);
            if (response.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> Delete(long replyId)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.DeleteAsync($"api/Replies/delete-reply/?replyId={replyId}");
            if (response.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> UpdateReply(ReplyUpdateModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.PutAsync($"api/Replies/update-reply", httpContent);
            if (response.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<ReplyViewModel> GetReply(long replyId)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync($"api/Replies/get-reply/?replyId={replyId}");
            var body = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ReplyViewModel>(body);
           
            return result;
        }
    }
}
