using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MoBaEsport.Application.Model.ChatBoxModel;
using MoBaEsport.Application.Model.MessageModel;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MoBaEsport.APIServices
{
    public class ChatBoxAPI : IChatBoxAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ChatBoxAPI(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<bool> CreateChatBox(ChatBoxCreateModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.PostAsync($"api/ChatBoxes/create-chatbox", httpContent);
            if (response.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> CreateMessage(MessageCreateModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.PostAsync($"api/Messages/create-message", httpContent);
            if(response.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> DeleteMessage(long messageId)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.DeleteAsync($"api/Messages/delete-message/?messId={messageId}");
            if(response.IsSuccessStatusCode) return true;
            return false;

        }

        public async Task<ChatBoxViewModel> GetChatBox(long chatboxId)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync($"api/ChatBoxs/get-chatbox/?chatboxId={chatboxId}");
            var body = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ChatBoxViewModel>(body);
            return result;
        }

        public async Task<List<MessageViewModel>> GetMessages(long chatboxId)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync($"api/Messages/get-message/?chatboxId={chatboxId}");
            var body = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<MessageViewModel>>(body);
            return result;
        }
    }
}
