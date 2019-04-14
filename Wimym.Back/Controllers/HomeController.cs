using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wimym.Back.Models;

namespace Wimym.Back.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICurrentUserFactory _currentUser;

        public HomeController(
            ICurrentUserFactory currentUser
        )
        {
            _currentUser = currentUser;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        //public class HomeController : Controller
        //{
        //    private readonly ICurrentUserFactory _currentUser;

        //    public HomeController(
        //        ICurrentUserFactory currentUser
        //    )
        //    {
        //        _currentUser = currentUser;
        //    }
        //    public IActionResult Index()
        //    {
        //        return View();
        //    }

        //    public IActionResult Privacy()
        //    {
        //        return View();
        //    }


        //}

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
