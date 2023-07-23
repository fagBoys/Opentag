using System.Security.Claims;
using Berlance.Core.Generator;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Vira.Core.Convertors;
using Vira.Core.DTOs;
using Vira.Core.Security;
using Vira.Core.Senders;
using Vira.Core.Services.Interfaces;
using Vira.Web.Shared.Entities.User;

namespace Vira.Web.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private IUserService _userService;
        private IViewRenderService _viewRender;

        public AccountController(IUserService userService, IViewRenderService viewRender)
        {
            _userService = userService;
            _viewRender = viewRender;
        }

        #region Register

        [HttpPost]
        [Route("Register")]
        public RegisterViewModel Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return register;
            }


            if (_userService.IsExistUserName(register.UserName))
            {
                ModelState.AddModelError("UserName", "نام کاربری معتبر نمی باشد");
                return register;

            }

            if (_userService.IsExistEmail(FixedText.FixEmail(register.Email)))
            {
                ModelState.AddModelError("Email", "ایمیل معتبر نمی باشد");
                return register;
            }


            User user = new User()
            {
                ActiveCode = NameGenerator.GenerateUniqCode(),
                Email = FixedText.FixEmail(register.Email),
                IsActive = false,
                Password = PasswordHelper.EncodePasswordMd5(register.Password),
                RegisterDate = DateTime.Now,
                UserAvatar = "Defult.jpg",
                UserName = register.UserName
            };
            _userService.AddUser(user);

            #region Send Activation Email

            string body = _viewRender.RenderToStringAsync("_ActiveEmail", user);
            SendEmail.Send(user.Email, "فعالسازی", body);

            #endregion
            return register;

        }


        #endregion

        #region Login

        [HttpPost]
        [Route("Login")]
        public LoginViewModel Login(LoginViewModel login , string ReturnUrl = "/")
        {
            if (!ModelState.IsValid)
            {
                return login;
            }

            var user = _userService.LoginUser(login);
            if (user != null)
            {
                if (user.IsActive)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                        new Claim(ClaimTypes.Name,user.UserName)
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = login.RememberMe
                    };
                    HttpContext.SignInAsync(principal, properties);

                    ViewBag.IsSuccess = true;

                    return login;

                }
                else
                {
                    ModelState.AddModelError("Email", "حساب کاربری شما فعال نمی باشد");
                }
            }
            ModelState.AddModelError("Email", "کاربری با مشخصات وارد شده یافت نشد");
                    return login;
        }

        #endregion

        #region Active Account
        [HttpGet]
        [Route("ActiveAccount/{activeCode}")]
        public IActionResult ActiveAccount(string activeCode)
        {
            ViewBag.IsActive = _userService.ActiveAccount(activeCode);
            return View();
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
        [HttpGet]
        [Route("ForgotPassword")]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public ActionResult ForgotPassword(ForgotPasswordViewModel forgot)
        {
            if (!ModelState.IsValid)
                return View(forgot);

            string fixedEmail = FixedText.FixEmail(forgot.Email);
            
            User user = _userService.GetUserByEmail(fixedEmail);

            if (user == null)
            {
                ModelState.AddModelError("Email", "کاربری یافت نشد");
                return View(forgot);
            }

            string bodyEmail = _viewRender.RenderToStringAsync("_ForgotPassword", user);
            SendEmail.Send(user.Email, "بازیابی حساب کاربری", bodyEmail);
            ViewBag.IsSuccess = true;

            return View();
        }
        #endregion

        #region Reset Password
        [HttpGet]
        [Route("ResetPassword/{id}")]
        public ActionResult ResetPassword(string id)
        {
            return View(new ResetPasswordViewModel()
            {
                ActiveCode = id
            });
        }


        [HttpPost]
        [Route("ResetPassword")]
        public ActionResult ResetPassword(ResetPasswordViewModel reset)
        {
            if (!ModelState.IsValid)
                return View(reset);

            User user = _userService.GetUserByActiveCode(reset.ActiveCode);

            if (user == null)
                return NotFound();

            string hashNewPassword = PasswordHelper.EncodePasswordMd5(reset.Password);
            user.Password = hashNewPassword;
            _userService.UpdateUser(user);

            return Redirect("/Login");

        }
        #endregion
    }
}