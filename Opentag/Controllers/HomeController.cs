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
            if(ModelState.IsValid)
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

            return View();
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
        
        
        [HttpPost]
        public IActionResult AddOrder(Order AddOrder)
        {            
            
            //EF core code

            ApplicationDbContext context = new ApplicationDbContext();

            context.Order.Add(AddOrder);

            context.SaveChanges();

            //EF core code ends


            ///////    Send Email     ///////
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("vira.co", "viradeveloper.co@gmail.com");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("vira.co", "viradeveloper.co@gmail.com");
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
            client.Authenticate("viradeveloper.co@gmail.com", "Vira2020");
            client.Send(message);
            ///////    Send Email     ///////

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
