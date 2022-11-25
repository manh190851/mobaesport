using MoBaEsport.Application.Model.FriendModel;
using MoBaEsport.Data.EntityModel;
using MoBaEsport.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Systems.UserServiceModel
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime DOB { get; set; }
        public string? Phone { get; set; }
        public string? Nation { get; set; }
        public string? City { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime LastLogin { get; set; }
        public LoginStatus LoginStatus { get; set; }
        public UserStatus UserStatus { get; set; }
        public string Email { get; set; }
        public List<FriendViewModel> friendList { get; set; }
    }
}
