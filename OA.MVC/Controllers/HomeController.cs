using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OA.MVC.Common.Base;
using OA.MVC.Models;
using OA.Services.Auth;
using OA.Services.Core.Menu;
using OA.Services.Core.Message;

namespace OA.MVC.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMenuService _menu;
        private readonly IOAMsgService _message;

        public HomeController(ILogger<HomeController> logger, IMenuService menu, IOAMsgService message)
        {

            _logger = logger;
            _menu = menu;
            _message = message;
        }

        public IActionResult Index()
        {
           // _message.CreateUserMessage("sdsad", "dsdsds", "dsdsds", "dsadfwesad", 1);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
