using MoBaEsport.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Systems.UserServiceModel
{
    public class UserManagerModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Fullname { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime DOB { get; set; }
        public string? Phone { get; set; }
        public string? Nation { get; set; }
        public string? City { get; set; }
        public string Email { get; set; }
        public UserStatus userStatus { get; set; }
        public LoginStatus loginStatus { get; set; }
    }
}
