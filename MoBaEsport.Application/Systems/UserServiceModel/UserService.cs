using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MoBaEsport.Data.DBContextModel;
using MoBaEsport.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MoBaEsport.Application.Systems.UserServiceModel
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;
        private readonly ESportDbContext _db;

        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, 
            IConfiguration config, ESportDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
            _db = context;
        }

        public async Task<string> Login(LoginRequestModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null) throw new Exception("UserName does not exist");

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true);
            if(!result.Succeeded) { return null; }

            var role = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.Fullname),
                new Claim(ClaimTypes.DateOfBirth, user.DOB.ToString()),
                new Claim(ClaimTypes.MobilePhone, user.Phone),
                new Claim(ClaimTypes.Role, string.Join(", ", role)),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> Register(RegisterRequestModel model)
        {
            var user = new AppUser()
            {
                Fullname = model.Fullname,
                Email = model.Email,
                UserName = model.UserName,
                Phone = model.Phone,
                Gender = model.Gender,
                DOB = model.DOB
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded) { return null; }

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.Fullname),
                new Claim(ClaimTypes.DateOfBirth, user.DOB.ToString()),
                new Claim(ClaimTypes.MobilePhone, user.Phone),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<List<UserManagerModel>> GetListUser()
        {
            List<UserManagerModel> managerList = new List<UserManagerModel>();
            var users = _db.Users.ToList();
            foreach(var user in users)
            {
                UserManagerModel model = new UserManagerModel()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Fullname = user.Fullname,
                    DOB = user.DOB,
                    Gender = user.Gender,
                    Phone = user.Phone,
                    City = user.City,
                    Nation = user.Nation,
                    Email = user.Email,
                    loginStatus = user.LoginStatus,
                    userStatus = user.UserStatus
                };
                managerList.Add(model);
            }
            return managerList;
        }

        public async Task<UserViewModel> GetUserProfile(Guid userId)
        {
            var user = await _db.Users.FindAsync(userId);

            if (user == null) throw new Exception();

            var profile = new UserViewModel()
            {
                Id = user.Id,
                Fullname = user.Fullname,
                Gender = user.Gender,
                Phone = user.Phone,
                DOB = user.DOB,
                Email = user.Email,
                City = user.City,
                Nation = user.Nation,
                ImageUrl = user.ImageUrl
            };

            return profile;
        }

        public Task<bool> IsLockedUser()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUnlockedUser()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateProfile(Guid userId, UserUpdateModel model)
        {
            if(await _userManager.Users.AnyAsync(m => m.Email == model.Email && m.Id != userId))
            {
                return false;
            }

            var user = await _userManager.FindByIdAsync(userId.ToString());
            user.Fullname = model.Fullname;
            user.Email = model.Email;
            user.DOB = model.DOB;
            user.Gender = model.Gender;
            user.Phone = model.Phone;
            user.Nation = model.Nation;
            user.City = model.City;

            var result = await _userManager.UpdateAsync(user);
            if(!result.Succeeded) return false; 
            return true;
        }

        public async Task<UserUpdateModel> GetUserById(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if(user == null) { return null; }
            var userView = new UserUpdateModel()
            {
                Id = user.Id,
                Fullname = user.Fullname,
                Gender = user.Gender,
                DOB = user.DOB,
                Phone = user.Phone,
                Nation = user.Nation,
                City = user.City,
                Email = user.Email
            };
            return userView;
        }
        public async Task<List<UserViewModel>> GetSearchingUser(string key)
        {
            var users = _userManager.Users.Where(i => i.Fullname.ToLower().Contains(key));
            List<UserViewModel> result = new List<UserViewModel>();
            foreach (var user in users)
            {
                UserViewModel userView = new UserViewModel()
                {
                    Id = user.Id,
                    Fullname = user.Fullname,
                    Gender = user.Gender,
                    DOB = user.DOB,
                    Email = user.Email,
                    City = user.City,
                    Nation = user.Nation,
                    ImageUrl = user.ImageUrl,
                    Phone = user.Phone,
                };
                result.Add(userView);
            }
            return result;
        }

        public async Task<List<Game>> GetGamePlay(Guid userId)
        {
            var gameplays = _db.GamePlayers.ToList().Where(i => i.playerId == userId);
            List<Game> result = new List<Game>();
            foreach(var gameplay in gameplays)
            {
                var game = await _db.Games.FindAsync(gameplay.gameId);
                result.Add(game);
            }
            return result;
        }

        public async Task<bool> AccessGamePlay(long gameId, Guid userId)
        {
            var gameplayers = new GamePlayer()
            {
                gameId = gameId,
                playerId = userId,
            };
            _db.GamePlayers.Add(gameplayers);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
