namespace MoBaEsport.Application.Systems.UserServiceModel
{
    public class LoginRequestModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; } 
    }
}