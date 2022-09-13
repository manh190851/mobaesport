using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoBaEsport.Data.Enum
{
    public enum GenderEnum
    {
        Male,
        Female
    }

    public enum UserStatus
    {
        Availablility,
        Locked
    }

    public enum FriendStatus
    {
        Friend,
        Unfriend,
        Block,
        Requesting,
    }

    public enum FollowStatus
    {
        Following,
        UnFollowing
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
        Like,
        Dislike
    }

    public enum LoginStatus
    {
        Login,
        Logoff
    }
}
