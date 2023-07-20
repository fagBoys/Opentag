using Microsoft.AspNetCore.Mvc;
using System.Net;
using Vira.Core.DTOs.Main;
using Vira.Core.Services.Interfaces;

namespace Vira.Web.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public void AddVisitHomePage()
        {
            string ip = Response.HttpContext.Connection.RemoteIpAddress.ToString();

            if (ip == "::1")
            {
                ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
            }
            _userService.AddVisitHomePage(ip);
        }

        [HttpPost]
        public string AddContactUs([FromBody] AddContact StudentVM)
        {
            _userService.AddContactUs(StudentVM);
            return "successful";
        }
    }
}
