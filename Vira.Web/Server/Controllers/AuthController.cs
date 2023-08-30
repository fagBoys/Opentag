using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Vira.Core.DTOs;
using Vira.Core.Services.Interfaces;
using Vira.Web.Shared;
using Microsoft.IdentityModel.Tokens;
using Vira.Web.Shared.Entities.User;
using System.Security.Claims;
using Berlance.Core.Generator;
using Vira.Core.Convertors;

namespace Vira.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("RegisterUser")]
        public OperationResult<string> Register(RegisterViewModel register)
        {
            var opration = new OperationResult<string>();

            if (!ModelState.IsValid)
            {
                return opration.Failed(ApplicationMessages.ModelState);
            }


            if (_userService.IsExistUserName(register.UserName))
            {
                return opration.Failed(ApplicationMessages.ModelState);
            }

            if (_userService.IsExistEmail(FixedText.FixEmail(register.Email)))
            {
                return opration.Failed(ApplicationMessages.ModelState);
            }


            User user = new User()
            {
                ActiveCode = NameGenerator.GenerateUniqCode(),
                Email = FixedText.FixEmail(register.Email),
                IsActive = true,
                Password = BCrypt.Net.BCrypt.HashPassword(register.Password),
                RegisterDate = DateTime.Now,
                UserAvatar = "Defult.jpg",
                UserName = register.UserName
            };
            _userService.AddUser(user);

            #region Send Activation Email

            //string body = _viewRender.RenderToStringAsync("_ActiveEmail", user);
            //SendEmail.Send(user.Email, "فعالسازی", body);

            #endregion

            return opration.Succedded("ثبت نام با موفقیت انجام شد!");
        }

        [HttpPost]
        [Route("Login")]
        public OperationResult<string> Login(LoginViewModel login, string ReturnUrl = "/")
        {
            var opration = new OperationResult<string>();
            if (login.Password == null || login.Password == null)
            {
                return opration.Failed(ApplicationMessages.ModelState);
            }

            var user = _userService.LoginUser(login);
            if (user != null)
            {
                if (user.IsActive)
                {
                    opration.Data = CreateToken(user);

                    return opration.Succedded();

                }
                else
                {
                    return opration.Failed(ApplicationMessages.RecordNotFound);
                }
            }

            return opration.Failed(ApplicationMessages.RecordNotFound);

        }


        private string CreateToken(User user)
        {


            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Email)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            JwtSecurityToken token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            string? jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

    }
}
