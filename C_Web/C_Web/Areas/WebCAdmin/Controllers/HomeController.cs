using C_Web.Entity.SYS;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Web_SYSList_Services;
using WebC.Generic.Repository;

namespace C_Web.Areas.WebCAdmin.Controllers
{
    [Area("WebCAdmin")]
    public class HomeController : Controller
    {
        private readonly ISYSList_Services _ISYSList_Services;
        
        public HomeController (ISYSList_Services _ISYSList_Services)
        {
            this._ISYSList_Services = _ISYSList_Services;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewMainMenu()
        {
            List<SYS_List> alllist = _ISYSList_Services.GetAllSYSList();
            return PartialView("_LeftData", alllist);
        }
    }
}
