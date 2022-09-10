using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoBaEsport.Data.Enum;

namespace MoBaEsport.Data.EntityModel
{
    public class AppUser : IdentityUser<Guid>
    {
        public string Fullname { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public string Nation { get; set; }
        public string City { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime LastLogin { get; set; }
        public LoginStatus LoginStatus { get; set; }
        public UserStatus UserStatus { get; set; }
        public List<Friend>? RequestFriends { get; set; }
        public List<Friend>? AcceptFriends { get; set; }
        public List<Follow>? Following { get; set; }
        public List<Follow>? Followers { get; set; }
        public List<Post>? Posts { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<Reaction>? Reactions { get; set; }
        public List<Reply>? Replys { get; set; }
        public List<Message>? SendMessage { get; set; }
        //public List<ChatBox>? OwnerChatBoxes { get; set; }
        //public List<ChatBox>? ChatBoxes { get; set; }

    }
}
