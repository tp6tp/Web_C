using C_Web.Extension;
using C_WebDTO.CommonDTO;
using C_WebDTO.Customer;
using C_WebDTO.SessionDTO;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Web_Customer_Services;

namespace C_Web.Areas.CustomerInfo.Controllers
{
    [Area("CustomerInfo")]
    public class CustomerBasicController : Controller
    {
        private readonly ICustomer_Services _ICustomer_Services;
        public CustomerBasicController(ICustomer_Services _ICustomer_Services)
        {
            this._ICustomer_Services = _ICustomer_Services;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewCusInfoBasic()
        {
            return View("CusBasic");
        }
        public IActionResult ViewCusContactBasic()
        {
            return View("ContactBasic");
        }
        #region CusBasic
        [HttpPost]
        public IActionResult ViewIndustrialBasicTable()
        {
            DataTableDTO data = new DataTableDTO
            {
                data = _ICustomer_Services.GetCusIndustrialBasicTable()
            };
            return Json(data);
        }
        [HttpPost]
        public IActionResult ViewAttributeBasicTable()
        {
            DataTableDTO data = new DataTableDTO
            {
                data = _ICustomer_Services.GetCusAttributeBasicTable()
            };
            return Json(data);
        }
        [HttpPost]
        public IActionResult CreateIndustrialBasic([FromBody]Customer_BasicDTO basicDTO)
        {
            basicDTO.UserId = HttpContext.Session.GetObject<UserSessionDTO>("User").UserId;
            if (_ICustomer_Services.CreateIndustrial(basicDTO))
            {
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
        [HttpPost]
        public IActionResult CreateAttributeBasic([FromBody] Customer_BasicDTO basicDTO)
        {
            var userid = HttpContext.Session.GetObject<UserSessionDTO>("User").UserId;
            if (_ICustomer_Services.CreateAttribute(basicDTO))
            {
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
        [HttpPost]
        public IActionResult EditIndustrialBasic([FromBody]Customer_BasicDTO basicDTO)
        {
            basicDTO.UserId = HttpContext.Session.GetObject<UserSessionDTO>("User").UserId;
            if (_ICustomer_Services.EditIndustrial(basicDTO))
            {
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
        [HttpPost]
        public IActionResult EditAttributeBasic([FromBody] Customer_BasicDTO basicDTO)
        {
            basicDTO.UserId = HttpContext.Session.GetObject<UserSessionDTO>("User").UserId;
            if (_ICustomer_Services.EditAttribute(basicDTO))
            {
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
        [HttpPost]
        public IActionResult DeleteIndustrialBasic([FromBody] Customer_BasicDTO basicDTO)
        {
            basicDTO.UserId = HttpContext.Session.GetObject<UserSessionDTO>("User").UserId;
            if (_ICustomer_Services.DeleteIndustrial(basicDTO))
            {
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
        [HttpPost]
        public IActionResult DeleteAttributeBasic([FromBody] Customer_BasicDTO basicDTO)
        {
            basicDTO.UserId = HttpContext.Session.GetObject<UserSessionDTO>("User").UserId;
            if (_ICustomer_Services.DeleteAttribute(basicDTO))
            {
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
        #endregion
        #region contactBasic
        [HttpPost]
        public IActionResult ViewContactTypeBasicTable()
        {
            DataTableDTO data = new DataTableDTO
            {
                data = _ICustomer_Services.GetConTypeBasicTable()
            };
            return Json(data);
        }
        public IActionResult ViewContactAreaBasicTable()
        {
            DataTableDTO data = new DataTableDTO
            {
                data = _ICustomer_Services.GetConAreaBasicTable()
            };
            return Json(data);
        }
        [HttpPost]
        public IActionResult CreateContactTypeBasic([FromBody] Customer_BasicDTO basicDTO)
        {
            basicDTO.UserId = HttpContext.Session.GetObject<UserSessionDTO>("User").UserId;
            if (_ICustomer_Services.CreateContactType(basicDTO))
            {
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }  
        [HttpPost]
        public IActionResult CreateContactAreaBasic([FromBody] Customer_BasicDTO basicDTO)
        {
            basicDTO.UserId = HttpContext.Session.GetObject<UserSessionDTO>("User").UserId;
            if (_ICustomer_Services.CreateContactArea(basicDTO))
            {
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
        [HttpPost]
        public IActionResult EditContactTypeBasic([FromBody] Customer_BasicDTO basicDTO)
        {
            basicDTO.UserId = HttpContext.Session.GetObject<UserSessionDTO>("User").UserId;
            if (_ICustomer_Services.EditContactType(basicDTO))
            {
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
        [HttpPost]
        public IActionResult EditContactAreaBasic([FromBody] Customer_BasicDTO basicDTO)
        {
            basicDTO.UserId = HttpContext.Session.GetObject<UserSessionDTO>("User").UserId;
            if (_ICustomer_Services.EditContactArea(basicDTO))
            {
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
        [HttpPost]
        public IActionResult DeleteContactTypeBasic([FromBody] Customer_BasicDTO basicDTO)
        {
            basicDTO.UserId = HttpContext.Session.GetObject<UserSessionDTO>("User").UserId;
            if (_ICustomer_Services.DeleteContactType(basicDTO))
            {
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
        [HttpPost]
        public IActionResult DeleteContactAreaBasic([FromBody] Customer_BasicDTO basicDTO)
        {
            basicDTO.UserId = HttpContext.Session.GetObject<UserSessionDTO>("User").UserId;
            if (_ICustomer_Services.DeleteContactArea(basicDTO))
            {
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
        #endregion
    }
}
