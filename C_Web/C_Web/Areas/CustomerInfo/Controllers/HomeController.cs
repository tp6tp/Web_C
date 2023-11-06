using Microsoft.AspNetCore.Mvc;

namespace C_Web.Areas.CustomerInfo.Controllers
{
    [Area("CustomerInfo")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
