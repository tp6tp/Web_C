using Microsoft.AspNetCore.Mvc;
using Web_SYSList_Services;
using C_WebDTO.CommonDTO;
using C_Web.Entity.SYS;
using C_Web.Extension;
using C_WebDTO.SessionDTO;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace C_Web.Areas.WebCAdmin.Controllers
{
    [Area("WebCAdmin")]
    public class SYSListController : Controller
    {
        private readonly ISYSList_Services _ISYSList_Services;
        public SYSListController(ISYSList_Services _ISYSList_Services)
        {
            this._ISYSList_Services = _ISYSList_Services;
        }
        public IActionResult Index(long? SYSListId=null)
        {
            if(SYSListId == null)
            {
                return View();
            }
            else
            {
                ViewBag.FAname = "上層功能：" +  _ISYSList_Services.GetFatherName(SYSListId);
                ViewBag.SYSListId= SYSListId;
                return View();
            }
            
        }
        public IActionResult CreateSYSListModal(long? SYSListId=null)
        {
            ViewBag.SYSListId = SYSListId;
            return PartialView("_Create");
        }
        public IActionResult EditSYSListModal(long Id)
        {
            SYS_List model = _ISYSList_Services.GetEditModel(Id);
            if (model == null)
                model = new SYS_List();
            return PartialView("_Edit", model);
        }
        [HttpPost]
        public IActionResult ViewSYSListTable(int? SYSListId=null)
        {
            DataTableDTO data = new()
            {
                data = _ISYSList_Services.GetSYSListTable(SYSListId)
            };
            return Json(data);
        }
        [HttpPost]
        public IActionResult CreateSYSList([FromBody] FetchDTO ListModel)  
        {
            ListModel.MUser = HttpContext.Session.GetObject<UserSessionDTO>("User").UserId;
            if (_ISYSList_Services.CreateSYSList(ListModel))
                return Json(new { Success = true });
            else
                return Json(new { Success = false });
        }
        [HttpPost]
        public IActionResult EditSYSList([FromBody] SYS_List ListModel)
        {
            ListModel.MUser = HttpContext.Session.GetObject<UserSessionDTO>("User").UserId;
            if (_ISYSList_Services.EditSYSList(ListModel))
                return Json(new { Success = true });
            else
                return Json(new { Success = false });
        }
        [HttpPost]
        public IActionResult EditOnOff([FromBody] FetchDTO DTO)
        {
            if (_ISYSList_Services.OnOff(DTO))
                return Json(new { Success = true });
            else
                return Json(new { Success = false });
        }
        [HttpPost]
        public IActionResult ViewOrder([FromBody] FetchDTO DTO)
        {
            if(DTO.data.Length > 0)
            {
                if(_ISYSList_Services.SYSListOrder(DTO.data, DTO.order))
                    return Json(new { Success = true });
                else
                    return Json(new { Success = false });
            }
            else
                return Json(new { Success = false }); ;
        }
    }
}
