using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Vira.Core.DTOs.Main;
using Vira.Core.Services.Interfaces;
using Vira.Web.Shared;

namespace Vira.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("AddVisitHomePage")]
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
        [Route("AddContactUs")]
        public async Task<OperationResult<string>> AddContactUs(AddContact AddContact)
        {
           OperationResult<string> operation = new OperationResult<string>();

            if (AddContact == null)
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }
            _userService.AddContactUs(AddContact);

            return operation.Succedded();

        }


    }
}
