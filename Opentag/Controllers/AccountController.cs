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



        [HttpGet]
        public async Task<IActionResult> Article(int ArticleId)
        {
            DetailsViewModel DVM = new DetailsViewModel();
            ApplicationDbContext context = new ApplicationDbContext();
            DVM.article = context.Article.Include(A => A.Images).Where(B => B.ArticleId == ArticleId).SingleOrDefault();
            DVM.articlesList = context.Article.Include(A => A.Images).OrderByDescending(A => A.ArticleId).ToList().Take(4);
            ViewData["ArticleId"] = ArticleId;
            return View(DVM);

        }


        [HttpGet]
        public IActionResult AddArticle()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddArticle(AddArticleViewModel NewArticle)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext ArticleContext = new ApplicationDbContext();

                Article article = new Article();

                Tag tag;

                ArticleTag articleTag;


                article.Date = DateTime.Now;
                article.AuthorAccount = NewArticle.AuthorName;
                article.Title = NewArticle.Title;
                article.ShortBody = NewArticle.ShortBody;
                article.Body = NewArticle.Body;
                ArticleContext.Article.Add(article);
                ArticleContext.SaveChanges();

                //  Upload Article image started
                #region AticleImage

                ApplicationDbContext ArticleImageContext = new ApplicationDbContext();
                Image articleImage = new Image();
                articleImage.ImageName = NewArticle.ArticleImage.FileName;
                articleImage.ArticleId = article.ArticleId;
                articleImage.Primary = true;
                ArticleImageContext.Image.Add(articleImage);

                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, "img/article");
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }


                if (NewArticle.ArticleImage == null || NewArticle.ArticleImage.Length == 0)
                {
                    await Response.WriteAsync("Error");
                }

                var filePath = Path.Combine(uploadsRootFolder, NewArticle.ArticleImage.FileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await NewArticle.ArticleImage.CopyToAsync(fileStream).ConfigureAwait(false);
                }

                ArticleImageContext.SaveChanges();

                #endregion
                //  Upload Article image ended

                //  Upload Slides started
                #region Slides

                foreach (var slide in NewArticle.Slides)
                {
                    ApplicationDbContext SlideContext = new ApplicationDbContext();
                    Image newSlide = new Image();
                    newSlide.ImageName = slide.FileName;
                    newSlide.ArticleId = article.ArticleId;
                    newSlide.Primary = false;
                    SlideContext.Image.Add(newSlide);

                    var SlidesRootFolder = Path.Combine(_environment.WebRootPath, "img/detail");
                    if (!Directory.Exists(SlidesRootFolder))
                    {
                        Directory.CreateDirectory(SlidesRootFolder);
                    }

                    if (slide == null || slide.Length == 0)
                    {
                        await Response.WriteAsync("Error");

                    }

                    var slidepath = Path.Combine(SlidesRootFolder, slide.FileName);

                    using (var fileStream = new FileStream(slidepath, FileMode.Create))
                    {
                        await slide.CopyToAsync(fileStream).ConfigureAwait(false);
                    }

                    SlideContext.SaveChanges();
                }

                #endregion
                //  Upload Slides ended

                // Tags strated
                #region Tags
                ApplicationDbContext GetTag = new ApplicationDbContext();
                ApplicationDbContext TagInsertion = new ApplicationDbContext();
                foreach (var newtag in NewArticle.Tags)
                {
                    if (newtag != null)
                    {
                        var CheckTag = GetTag.Tag.FirstOrDefault(T => T.Name == newtag);
                        Tag InsertionObj = new Tag();
                        if (CheckTag == null)
                        {
                            InsertionObj.Name = newtag;
                            TagInsertion.Tag.Add(InsertionObj);
                            TagInsertion.SaveChanges();
                            TagInsertion.ArticleTag.Add(new ArticleTag { ArticleId = article.ArticleId, TagId = InsertionObj.TagId });
                            TagInsertion.SaveChanges();
                        }
                        else
                        {
                            TagInsertion.ArticleTag.Add(new ArticleTag { ArticleId = article.ArticleId, TagId = CheckTag.TagId });
                            TagInsertion.SaveChanges();
                        }
                    }
                }

                #endregion
                // Tags ended

                return RedirectToAction("AddArticle");
            }
            else if (!ModelState.IsValid)
            {
                return View(NewArticle);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult DeleteArticle(int id)
        {

            //EF core start
            ApplicationDbContext context = new ApplicationDbContext();
            Article article = context.Article.FirstOrDefault(o => o.ArticleId == id);
            context.Article.Remove(article);
            context.SaveChangesAsync();
            //EF core end

            return RedirectToAction("Articles");
        }

        [HttpPost]
        public IActionResult EditArticle(int id)
        {
            ApplicationDbContext GetArticle = new ApplicationDbContext();
            EditArticleViewModel EVM = new EditArticleViewModel();
            var TargetArticle = GetArticle.Article.Include(A => A.ArticleTags).ThenInclude(A => A.Tags).Include(A => A.Images).Where(A => A.ArticleId == id).FirstOrDefault();
            var SlideImages = GetArticle.Image.Where(A => A.ArticleId == id).Where(A => A.Primary == false).ToList();
            EVM.ForEditArticle = TargetArticle;
            EVM.ForEditSlideImages = SlideImages;
            return View(EVM);
        }

        //******************************


    }
}
