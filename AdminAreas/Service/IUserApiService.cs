using MoBaEsport.Application.Systems.UserServiceModel;

namespace AdminAreas.Service
{
    public interface IUserApiService
    {
        Task<string> Login(LoginRequestModel model);
        Task<string> Register(RegisterRequestModel model);
        Task<List<UserManagerModel>> GetListUsers(string token);
        Task<UserUpdateModel> GetUserById(Guid id, string token);
        Task<bool> UpdateProfile(Guid id, UserUpdateModel model, string token);
        Task<UserViewModel> GetProfileUser(Guid id, string token);
    }
}
