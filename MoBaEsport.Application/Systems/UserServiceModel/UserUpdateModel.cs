using MoBaEsport.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Application.Systems.UserServiceModel
{
    public class UserUpdateModel
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime DOB { get; set; }
        public string? Phone { get; set; }
        public string? Nation { get; set; }
        public string? City { get; set; }
    }
}
