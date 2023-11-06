using Microsoft.AspNetCore.Mvc;

namespace C_Web.Areas.CustomerInfo.Controllers
{
    [Area("CustomerInfo")]
    public class CustomerBasicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
