using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Berlance.Core.Generator;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Vira.Core.Convertors;
using Vira.Core.DTOs;
using Vira.Core.Senders;
using Vira.Core.Services.Interfaces;
using Vira.Web.Shared;
using Vira.Web.Shared.Entities.Main;
using Vira.Web.Shared.Entities.User;

namespace Vira.Web.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private IUserService _userService;
        private readonly IConfiguration _configuration;
        public AccountController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        #region Register

        [HttpPost]
        [Route("Register")]
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
                IsActive = false,
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


        #endregion

        #region Login

        [HttpPost]
        [Route("Login")]
        public OperationResult<string> Login(LoginViewModel login , string ReturnUrl = "/")
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
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                        new Claim(ClaimTypes.Name, user.Email)
                    };

                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                        .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                    var token = new JwtSecurityToken(
                        claims: claims,
                        expires: DateTime.Now.AddDays(1),
                        signingCredentials: creds);

                    opration.Data = new JwtSecurityTokenHandler().WriteToken(token);
                    return opration.Succedded();

                }
                else
                {
                    return opration.Failed(ApplicationMessages.RecordNotFound);
                }
            }

            return opration.Failed(ApplicationMessages.RecordNotFound);

        }

        #endregion

        #region Active Account
        [HttpGet]
        [Route("ActiveAccount/{activeCode}")]
        public bool ActiveAccount(string activeCode)
        {
            var code = _userService.ActiveAccount(activeCode);
            return code;
        }

        #endregion

        #region Logout
        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login");
        }

        #endregion


        #region Forgot Password

        [HttpPost]
        [Route("ForgotPassword")]
        public OperationResult<string> ForgotPassword(ForgotPasswordViewModel forgot)
        {
            var opration = new OperationResult<string>();

            if (!ModelState.IsValid)
                return opration.Failed(ApplicationMessages.ModelState);

            string fixedEmail = FixedText.FixEmail(forgot.Email);
            
            User user = _userService.GetUserByEmail(fixedEmail);

            if (user == null)
            {
                return opration.Failed("کاربری یافت نشد");
            }

            //string bodyEmail = _viewRender.RenderToStringAsync("_ForgotPassword", user);
            //SendEmail.Send(user.Email, "بازیابی حساب کاربری", bodyEmail);
            ViewBag.IsSuccess = true;

            return opration.Succedded();
        }
        #endregion

        #region Reset Password
        [HttpGet]
        [Route("ResetPassword/{id}")]
        public ResetPasswordViewModel ResetPassword(string id)
        {
            ResetPasswordViewModel passwordViewModel = new ResetPasswordViewModel();
            passwordViewModel.ActiveCode=id;
            return passwordViewModel;
        }


        [HttpPost]
        [Route("ResetPassword")]
        public OperationResult<string> ResetPassword(ResetPasswordViewModel reset)
        {
            var opration = new OperationResult<string>();

            if (!ModelState.IsValid)
                return opration.Failed(ApplicationMessages.ModelState);

            User user = _userService.GetUserByActiveCode(reset.ActiveCode);

            if (user == null)
                return opration.Failed(ApplicationMessages.ModelState);


            string hashNewPassword = BCrypt.Net.BCrypt.HashPassword(reset.Password);
            user.Password = hashNewPassword;
            _userService.UpdateUser(user);

            return opration.Succedded("/Login");

        }
        #endregion

        #region ContactUs

        [HttpGet]
        [Route("ListContactUs")]
        public List<Contact> ListContactUs()
        {
            return _userService.ListContactUs();
        }

        #endregion
    }
}