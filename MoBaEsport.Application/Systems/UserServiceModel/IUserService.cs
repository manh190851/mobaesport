using MoBaEsport.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Systems.UserServiceModel
{
    public interface IUserService
    {
        Task<string> Login(LoginRequestModel model);

        Task<string> Register(RegisterRequestModel model);

        Task<List<UserManagerModel>> GetListUser();

        Task<UserUpdateModel> GetUserById(Guid id);

        Task<bool> IsLockedUser();

        Task<bool> IsUnlockedUser();

        Task<UserViewModel> GetUserProfile(Guid userId);

        Task<bool> UpdateProfile(Guid id, UserUpdateModel model);
        Task<List<UserViewModel>> GetSearchingUser(string key);
        Task<List<Game>> GetGamePlay(Guid userId);
        Task<bool> AccessGamePlay(long gameId, Guid userId);

        
    }
}
