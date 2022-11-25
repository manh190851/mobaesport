using Microsoft.Extensions.Configuration;
using MoBaEsport.Application.Model.FollowModel;
using MoBaEsport.Application.Model.FriendModel;
using MoBaEsport.Application.Systems.UserServiceModel;
using MoBaEsport.Data.EntityModel;
using Newtonsoft.Json;
using NuGet.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.APIServices
{
    public class RelationshipAPI : IRelationshipAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public RelationshipAPI(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        //Follow
        public async Task<bool> CreateFollow(FollowCreateModel model, string token)
        {
            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.PostAsync($"/api/Follows/create-follow", httpContent);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<Follow> FindFollow(Guid targetId, Guid userId, string token)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync($"/api/Follows/find-follow/?targetId={targetId}&userId={userId}");
            var body = await response.Content.ReadAsStringAsync();
            var follows = JsonConvert.DeserializeObject<Follow>(body);

            return follows;
        }

        public async Task<bool> DeleteFollow(long followId, string token)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.DeleteAsync($"/api/Follows/delete-follow/?followId={followId}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public Task<List<UserViewModel>> GetFollowerList(Guid userId, string token)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserViewModel>> GetFollowingList(Guid userId, string token)
        {
            throw new NotImplementedException();
        }

        //Friend
        public async Task<bool> CreateFriend(FriendCreateModel model, string token)
        {
            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.PostAsync($"/api/Friends/create-friend-request", httpContent);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<List<FriendRequestModel>> GetFriendRequest(Guid userId, string token)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync($"/api/Friends/get-list-friend-request/?userId={userId}");
            var body = await response.Content.ReadAsStringAsync();
            var request = JsonConvert.DeserializeObject<List<FriendRequestModel>>(body);
            return request;
        }

        public async Task<bool> ConfirmRequest(long friendId, string token)
        {
            var json = JsonConvert.SerializeObject(friendId);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.PatchAsync($"/api/Friends/confirm-request/?friendid={friendId}", httpContent);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteRequest(long friendId, string token)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.DeleteAsync($"/api/Friends/delete-friend/?friendId={friendId}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<List<FriendViewModel>> GetFriendList(Guid userId, string token)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
             client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync($"/api/Friends/get-list-friend/?userId={userId}");
            var body = await response.Content.ReadAsStringAsync();
            var request = JsonConvert.DeserializeObject<List<FriendViewModel>>(body);
            return request;
        }

        public async Task<Friend> GetFriend(Guid userId, Guid targetId, string token)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync($"/api/Friends/get-friend/?userId={userId}&targetId={targetId}");
            var body = await response.Content.ReadAsStringAsync();
            var request = JsonConvert.DeserializeObject<Friend>(body);
            return request;
        }
    }
}
