using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wimym.Common;

namespace Wimym.Frontend.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICurrentUserFactory _currentUser;

        public HomeController(
            ICurrentUserFactory currentUser
        )
        {
            _currentUser = currentUser;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
