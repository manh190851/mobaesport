using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Data.Enum
{
    public enum GenderEnum
    {
        Default,
        Male,
        Female,
        Other
    }

    public enum UserStatus
    {
        Availablility = 0,
        Locked = 1
    }

    public enum FriendStatus
    {
        Unfriend = 0,
        Friend = 1,
        Block = 2,
        Requesting = 3,
    }

    public enum FollowStatus
    {
        UnFollowing = 0,
        Following = 1
    }

    public enum PostStatus
    {
        Public = 0,
        Private = 1,
        Locked = 2,
        Hidden = 3,
        Reporting = 4
    }

    public enum Reactions
    {
        Like = 0,
        Dislike = 1
    }

    public enum LoginStatus
    {
        Login = 0,
        Logoff = 1
    }
}
