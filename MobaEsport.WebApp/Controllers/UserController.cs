using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using MoBaEsport.APIServices;
using MoBaEsport.Application.Model.ChatBoxModel;
using MoBaEsport.Application.Model.FollowModel;
using MoBaEsport.Application.Model.FriendModel;
using MoBaEsport.Application.Systems.UserServiceModel;
using MoBaEsport.Data.EntityModel;
using MoBaEsport.Data.Enum;
using NuGet.Protocol;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MobaEsport.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAPI _userApi;
        private readonly IRelationshipAPI _relationshipAPI;
        private readonly IConfiguration _configuration;
        private const string tokenKey = "Token";
        private const string errorKey = "Error";
        private string bearerToken = "";
        private readonly IChatBoxAPI _chatBoxAPI;

        public UserController(IUserAPI userApi, IConfiguration configuration, IRelationshipAPI relationshipAPI, IChatBoxAPI chatBoxAPI)
        {
            _userApi = userApi;
            _configuration = configuration;
            _relationshipAPI = relationshipAPI;
            _chatBoxAPI = chatBoxAPI;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", model);
            }

            var token = await _userApi.Login(model);
            var userPrincipal = this.ValidateToken(token);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IsPersistent = true,
            };
            HttpContext.Session.SetString(tokenKey, token);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                userPrincipal,
                authProperties);
            

            return RedirectToAction("Index", "Home");

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", model);
            }

            var token = await _userApi.Register(model);
            var userPrincipal = this.ValidateToken(token);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IsPersistent = true,
            };
            HttpContext.Session.SetString(tokenKey, token);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                userPrincipal,
                authProperties);

            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public async Task<IActionResult> ViewProfile(Guid userId)
        {
            bearerToken += HttpContext.Session.GetString(tokenKey);
            var user = await _userApi.GetProfile(userId, bearerToken);
            user.friendList = await _relationshipAPI.GetFriendList(userId, bearerToken);
            return View(user);
        }

        public async Task<IActionResult> EditProfile(Guid userId)
        {
            bearerToken += HttpContext.Session.GetString(tokenKey);
            var user = await _userApi.GetProfile(userId, bearerToken);
            return View(new UserUpdateModel
            {
                Id = userId,
                Fullname = user.Fullname,
                DOB = user.DOB,
                Gender = user.Gender,
                Phone = user.Phone,
                City = user.City,
                Nation = user.Nation,
                Email = user.Email,
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UserUpdateModel model)
        {
            bearerToken += HttpContext.Session.GetString(tokenKey);
            if (!ModelState.IsValid)
            {
                ViewData[errorKey] = "Edit Failed";
                return View(model);
            }
            var user = await _userApi.EditProfile(model, bearerToken);
            return RedirectToAction("ViewProfile", "User", new { userId = model.Id });

        }

        [HttpGet]
        public async Task<IActionResult> ListUser(Guid? userId)
        {
            bearerToken += HttpContext.Session.GetString(tokenKey);
            if (userId != null)
            {
                throw new NotImplementedException();
            }
            var user = await _userApi.GetListUsers(bearerToken);
            return View(user);
        }

        //Follow
        public async Task<IActionResult> Follow(Guid followingId, Guid userId)
        {
            bearerToken += HttpContext.Session.GetString(tokenKey);
            FollowCreateModel followRequest = new FollowCreateModel{
                FollowingId = followingId,
                FollowerId = userId,
                Created = DateTime.Now
            };
            var result = await _relationshipAPI.CreateFollow(followRequest, bearerToken);
            if(result == false)
            {
                ViewData[errorKey] = "Unsuccessfully";
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("ViewProfile", "User", new { userId = followRequest.FollowingId });
        }

        public async Task<IActionResult> UnFollow(Guid targetId, Guid userId)
        {
            bearerToken += HttpContext.Session.GetString(tokenKey);
            var follow = await _relationshipAPI.FindFollow(targetId, userId, bearerToken);
            if(follow == null)
            {
                ViewData[errorKey] = String.Format("Not Following");
            }
            var result = await _relationshipAPI.DeleteFollow(follow.FollowId, bearerToken);
            if(result == false)
            {
                ViewData[errorKey] = String.Format("Delete unsuccessfully");
            }
            return RedirectToAction("ViewProfile", "User", new { userId = targetId });
        }

        //Friend
        public async Task<IActionResult> CreateFriendRequest(Guid targetId, Guid userId)
        {
            bearerToken += HttpContext.Session.GetString(tokenKey);
            FriendCreateModel createModel = new FriendCreateModel
            {
                RequestId = userId,
                AcceptId = targetId,
                Created = DateTime.Now,
                Status = FriendStatus.Requesting
            };
            var result = await _relationshipAPI.CreateFriend(createModel, bearerToken);
            if(result == false)
            {
                ViewData[errorKey] = String.Format(errorKey);
            }
            return RedirectToAction("ViewProfile", "User", new { userId = targetId });

        }

        public async Task<IActionResult> ViewFriendRequest(Guid userId)
        {
            bearerToken += HttpContext.Session.GetString(tokenKey);
            var result = await _relationshipAPI.GetFriendRequest(userId, bearerToken);
            if(result == null)
            {
                ViewData[errorKey] = String.Format("Get error");
            }
            return View(result);
        }

        public async Task<IActionResult> ConfirmRequest(long friendId)
        {
            bearerToken += HttpContext.Session.GetString(tokenKey);
            var result = await _relationshipAPI.ConfirmRequest(friendId, bearerToken);
            var chatResult = await _chatBoxAPI.CreateChatBox(new ChatBoxCreateModel
            {
                friendId = friendId,
                Color = "blue"
            });
            if (result == false || chatResult == null)
            {
                ViewData[errorKey] = String.Format("Confirm error");
            }
            return RedirectToAction("ViewFriendRequest", "User", new { userId = User.Identity.GetUserId() });
        }

        public async Task<IActionResult> DeleteRequest(long friendId)
        {
            bearerToken += HttpContext.Session.GetString(tokenKey);
            var result = await _relationshipAPI.DeleteRequest(friendId, bearerToken);
            if(result == false)
            {
                ViewData[errorKey] = String.Format("Delete error");
            }
            return RedirectToAction("ViewFriendRequest", "User", new { userId = User.Identity.GetUserId() });
        }

        public async Task<IActionResult> ViewFriendList(Guid userId)
        {
            bearerToken += HttpContext.Session.GetString(tokenKey);
            var result = await _relationshipAPI.GetFriendList(userId, bearerToken);
            if(result != null)
            {
                ViewData[errorKey] = String.Format("Not Found");
            }
            return View(result);
        }

        public async Task<Friend> GetFriendObject(Guid userId, Guid targetId)
        {
            bearerToken += HttpContext.Session.GetString(tokenKey);
            var result = await _relationshipAPI.GetFriend(userId, targetId, bearerToken);
            return result;
        }

        //ChatBox
        public async Task<IActionResult> ViewChatBox(Guid userId, Guid targetId)
        {
            var friend = await this.GetFriendObject(userId, targetId);
            if (friend == null) throw new ArgumentNullException();
            var chatbox = await _chatBoxAPI.GetChatBox(friend.FriendId);
            if(chatbox == null)
            {
                ViewData[errorKey] = "Not Found chatbox";
            }
            return RedirectToAction("Index", "ChatBox", new { chatboxId = chatbox.chatboxId });
        }

        private ClaimsPrincipal ValidateToken(string token)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;
            validationParameters.ValidAudience = _configuration["Tokens:Issuer"];
            validationParameters.ValidIssuer = _configuration["Tokens:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(token, validationParameters, out validatedToken);
            return principal;
        }
    }
}
