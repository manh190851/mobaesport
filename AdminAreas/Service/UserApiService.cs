using MoBaEsport.Application.Model.ReactionModel;
using MoBaEsport.Application.Systems.UserServiceModel;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace AdminAreas.Service
{
    public class UserApiService : IUserApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public UserApiService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<List<UserManagerModel>> GetListUsers(string token)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync("/api/users/get-list-user");
            var body = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<UserManagerModel>>(body);
            return users;
        }

        public async Task<UserViewModel> GetProfileUser(Guid userId, string token)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync($"/api/users/get-profile-user/?userId={userId}");
            var body = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<UserViewModel>(body);
            return users;
        }

        public async Task<UserUpdateModel> GetUserById(Guid userId, string token)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync($"/api/users/get-user-byId/?userId={userId}");
            var body = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) { throw new Exception(); }
            var users = JsonConvert.DeserializeObject<UserUpdateModel>(body);
            return users;
        }

        public async Task<string> Login(LoginRequestModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.PostAsync("/api/users/login", httpContent);
            var token = await response.Content.ReadAsStringAsync();
            
            return token;
        }

        public async Task<string> Register(RegisterRequestModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.PostAsync($"/api/users/register", httpContent);
            var token = await response.Content.ReadAsStringAsync();

            return token;
        }

        public async Task<bool> UpdateProfile(Guid userId, UserUpdateModel model, string token)
        {
            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.PutAsync($"/api/users/update-profile/{userId}", httpContent);
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
            return true;
        }
    }
}
