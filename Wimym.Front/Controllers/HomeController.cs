namespace Wimym.Front.Config
{
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

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
}
