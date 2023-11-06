using Microsoft.AspNetCore.Mvc;

namespace C_Web.Areas.ProjectManage.Controllers
{
    [Area("ProjectManage")]
    public class LicenseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
