using Microsoft.AspNetCore.Mvc;
using MoBaEsport.Application.Model.FollowModel;
using MoBaEsport.Application.Model.FriendModel;
using MoBaEsport.Application.Systems.UserServiceModel;
using MoBaEsport.Data.EntityModel;

namespace MoBaEsport.APIServices
{
    public interface IUserAPI
    {
        //Systems
        Task<string> Login(LoginRequestModel model);
        Task<string> Register(RegisterRequestModel model);

        //Users Manager
        Task<List<UserViewModel>> GetListUsers(string token);


        //Profile
        Task<bool> EditProfile(UserUpdateModel model, string token);
        Task<UserViewModel> GetProfile(Guid userId, string token);
    }
}
