namespace Wimym.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class PsBaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}