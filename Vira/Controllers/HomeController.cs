using Vira.Core.Convertors;
using Vira.Core.Generator;
using Vira.Core.Services.Interfaces;
using Vira.DataLayer.Entities.Product;
using Vira.Web.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;
using Vira.Core.DTOs.Storage;
using Vira.Core.DTOs.Home;
using Vira.DataLayer.Entities.User;

namespace Vira.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUserService _userService;
        private IProductService _productService;
        private ISliderService _sliderService;
        IMessengerSupport _messengerSupport;


        public HomeController(ILogger<HomeController> logger, IUserService userService, IProductService productService, ISliderService sliderService, IMessengerSupport messengerSupport)
        {
            _logger = logger;
            _userService = userService;
            _productService = productService;
            _sliderService = sliderService;
            _messengerSupport = messengerSupport;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
