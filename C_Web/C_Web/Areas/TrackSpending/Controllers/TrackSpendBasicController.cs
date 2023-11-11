using Microsoft.AspNetCore.Mvc;

namespace C_Web.Areas.TrackSpending.Controllers
{
    [Area("TrackSpending")]
    public class TrackSpendBasicController : Controller
    {
        [HttpPost]
        public IActionResult Index()
        {
            return View("_CreateEdit");
        }
    }
}
