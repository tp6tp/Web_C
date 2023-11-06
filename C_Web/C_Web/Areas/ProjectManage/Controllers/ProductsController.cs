using Microsoft.AspNetCore.Mvc;

namespace C_Web.Areas.ProjectManage.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
