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

        Task<bool> Register(RegisterRequestModel model);
    }
}
