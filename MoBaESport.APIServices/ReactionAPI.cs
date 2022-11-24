using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MoBaEsport.Application.Model.ReactionModel;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MoBaEsport.APIServices
{
    public class ReactionAPI : IReactionAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ReactionAPI(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<bool> CreateReaction(ReactionCreateModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.PostAsync($"api/Reactions/create-reaction", httpContent);
            if (response.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> DeleteReaction(long reacId)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.DeleteAsync($"api/Reactions/delete-reaction/?reacId={reacId}");
            if (response.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<ReactionViewModel> GetReactionById(long reacId)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync($"api/Reactions/get-reaction/?reacId={reacId}");
            var body = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ReactionViewModel>(body);
            return result;
        }

        public async Task<bool> UpdateReaction(ReactionUpdateModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.PutAsync($"api/Reactions/update-reaction", httpContent);
            if (response.IsSuccessStatusCode) return true;
            return false;
        }
    }
}
