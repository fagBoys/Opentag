using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Opentag.Data;
using Opentag.Models;
using Opentag.ViewModels;
using Opentag.ViewModels.Account;

namespace Opentag.Controllers
{
    public class AccountController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        private readonly UserManager<Account> _userManager;

        private readonly SignInManager<Account> _signInManager;

        private readonly ILogger _logger;

        private readonly ApplicationDbContext _Context;


        public AccountController(IWebHostEnvironment environment, UserManager<Account> userManager, SignInManager<Account> signInManager, ILogger logger, ApplicationDbContext context)
        {
            _environment = environment;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _Context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = "Index")
        {

            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                ApplicationDbContext context = new ApplicationDbContext();
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
                Account Account = context.Account.Where(A => A.UserName == model.Username).FirstOrDefault();
                if (result.Succeeded && Account.IsAdmin && Account.IsActive)
                {

                    var claims = new List<Claim>
                    {
                        new Claim("Admin", "Admin")
                    };

                    var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    _logger.LogInformation("Admin logged in.");
                    return RedirectToAction(returnUrl);

                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("Admin account locked out.");
                    //return RedirectToLocal(nameof(Lockout));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            return View();

        }


        public IActionResult Dashboard()
        {
            return View();
        }



        //******************************


    }
}
