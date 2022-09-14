using MoBaEsport.Data.Enum;

namespace MoBaEsport.Application.Systems.UserServiceModel
{
    public class RegisterRequestModel
    {
        public string Fullname { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public string Nation { get; set; }
        public string City { get; set; }
        public string? ImageUrl { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}