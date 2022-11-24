using AdminAreas.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using MoBaEsport.Application.Systems.UserServiceModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Security.Claims;
using System.Text;

namespace AdminAreas.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApiService _userApiService;
        private readonly IConfiguration _configuration;
        private const string tokenKey = "Token";

        public UserController(IUserApiService userApiService, IConfiguration configuration)
        {
            _userApiService = userApiService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UserManager()
        {
            var token = HttpContext.Session.GetString(tokenKey);
            var userData = await _userApiService.GetListUsers(token);
            return View(userData);
        }

        [HttpGet]
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

            var token = await _userApiService.Login(model);
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

            var token = await _userApiService.Register(model);
            var userPrincipal = this.ValidateToken(token);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IsPersistent = true,
            };
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                userPrincipal,
                authProperties);

            return RedirectToAction("Index", "Home");

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

        public async Task<IActionResult> UserProfile(Guid userId)
        {
            var token = HttpContext.Session.GetString(tokenKey);
            var profile = await _userApiService.GetProfileUser(userId, token);
            return View(profile);
        }

        [HttpGet]
        public IActionResult UpdateProfile(Guid userId)
        {
            var token = HttpContext.Session.GetString(tokenKey);
            var user = _userApiService.GetUserById(userId, token);
            return View(user);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProfile(UserUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var token = HttpContext.Session.GetString(tokenKey);
            var user = _userApiService.UpdateProfile(model.Id, model, token);

            return RedirectToAction("User Manager", "User");
        }
    }
}
