using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Opentag.Data;
using Opentag.Models;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MimeKit.Utils;
using Opentag.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Opentag.Views;

namespace Opentag.Controllers
{
    public class HomeController : Controller
    {

        private IWebHostEnvironment _environment;
        private readonly ILogger<HomeController> _logger;


        public HomeController(IWebHostEnvironment environment, ILogger<HomeController> logger)
        {
            _environment = environment;
            _logger = logger;
        }


        /*public HomeController(ILogger<HomeController> logger)
        { 
        }*/

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Contact contact)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext Context = new ApplicationDbContext();
                Context.Contact.Add(contact);
                await Context.SaveChangesAsync();
                return View();
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(Contact contact)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            context.Add(contact);
            context.SaveChanges();

            return new RedirectResult("/Home/Contact");
        }

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Order()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddOrder(AddOrderViewModel AddOrder)
        {

            //EF core code

            ApplicationDbContext context = new ApplicationDbContext();
            Order order = new Order()
            { FullName = AddOrder.FullName, Discription = AddOrder.Discription, EmailAddress = AddOrder.EmailAddress, PhoneNumber = AddOrder.PhoneNumber, Subject = AddOrder.Subject };
            context.Order.Add(order);

            context.SaveChanges();

            //EF core code ends


            ///////    Send Email     ///////
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("Crest Couriers", "crestcouriers@gmail.com");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("Crest Couriers", "mjn220@gmail.com");
            message.To.Add(to);

            message.Subject = "New order";

            BodyBuilder bodyBuilder = new BodyBuilder();

            var mybody = @System.IO.File.ReadAllText(_environment.WebRootPath + @"\Email\emailbody-order.html");
            mybody = mybody.Replace("Value01", AddOrder.FullName.ToString());
            mybody = mybody.Replace("Value02", AddOrder.PhoneNumber.ToString());
            mybody = mybody.Replace("Value03", AddOrder.EmailAddress.ToString());
            mybody = mybody.Replace("Value04", AddOrder.Subject.ToString());
            mybody = mybody.Replace("Value05", AddOrder.Discription.ToString());

            bodyBuilder.HtmlBody = mybody;

            var usericon = bodyBuilder.LinkedResources.Add(_environment.WebRootPath + @"/Email/newuser.png");
            usericon.ContentId = MimeUtils.GenerateMessageId();

            bodyBuilder.HtmlBody = bodyBuilder.HtmlBody.Replace("{", "{{");
            bodyBuilder.HtmlBody = bodyBuilder.HtmlBody.Replace("}", "}}");
            bodyBuilder.HtmlBody = bodyBuilder.HtmlBody.Replace("{{0}}", "{0}");

            bodyBuilder.HtmlBody = string.Format(bodyBuilder.HtmlBody, usericon.ContentId);

            message.Body = bodyBuilder.ToMessageBody();


            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 465, true);
            client.Authenticate("crestcouriers@gmail.com", "jkqocclafqidqtyr");
            client.Send(message);
            ///////    Send Email     ///////

            return View();
        }



        [HttpGet]
        //[Route("Blog")]
        public async Task<IActionResult> Blog(int? pageNumber)
        {
      //EF core start

            ApplicationDbContext context = new ApplicationDbContext();
            IEnumerable<Article> articles = context.Article.Include(A => A.Images).OrderByDescending(A => A.ArticleId);

            PaginatedList<Article> ArticleList = await PaginatedList<Article>.CreateAsunc((IQueryable<Article>)articles, pageNumber ?? 1, 4);


            //EF core end
            return View(ArticleList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        //*********************************
        [HttpGet]
        public async Task<IActionResult> Article(int ArticleId)
        {
            //DetailsViewModel DVM = new DetailsViewModel();
            //ApplicationDbContext context = new ApplicationDbContext();
            //DVM.article = context.Article.Include(A => A.Images).Where(B => B.ArticleId == ArticleId).SingleOrDefault();
            //DVM.articlesList = context.Article.Include(A => A.Images).OrderByDescending(A => A.ArticleId).ToList().Take(4);
            //ViewData["ArticleId"] = ArticleId;
            return View(/*DVM*/);
            
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
