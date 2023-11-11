using C_Web.Entity.TrackSpend;
using C_Web.Entity.TrackSpend.Enum;
using C_Web.Extension;
using C_WebDTO.SessionDTO;
using C_WebDTO.TrackSpendDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Web_TrackSpend_Services;
using WebC.Generic.Repository;

namespace C_Web.Areas.TrackSpending.Controllers
{
    [Area("TrackSpending")]
    public class TrackSpendController : Controller
    {
        private readonly ITrackSpend_Services _ITrackSpend_Services;
        public TrackSpendController(ITrackSpend_Services _ITrackSpend_Services)
        {
            this._ITrackSpend_Services = _ITrackSpend_Services;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateModal()
        {
            long UserId = HttpContext.Session.GetObject<UserSessionDTO>("User").UserId;
            List<ClassifyDTO> classList = _ITrackSpend_Services.GetClassifyInfoList(UserId);
            ViewBag.incomeList = classList.Where(x => x.IncomeOrExpenses == IncomeOrExpensesEnum.收入).OrderBy(x => x.ClassfyTypeId).ToList();
            ViewBag.expensesList = classList.Where(x => x.IncomeOrExpenses == IncomeOrExpensesEnum.支出).OrderBy(x => x.ClassfyTypeId).ToList();
            return PartialView("_Create");
        }

        public IActionResult ViewClassIcon()
        {
            long UserId = HttpContext.Session.GetObject<UserSessionDTO>("User").UserId;
            List<ClassifyDTO> classList = _ITrackSpend_Services.GetClassifyInfoList(UserId);
            ViewBag.incomeList = classList.Where(x => x.IncomeOrExpenses == IncomeOrExpensesEnum.收入).OrderBy(x => x.ClassfyTypeId).ToList();
            ViewBag.expensesList = classList.Where(x => x.IncomeOrExpenses == IncomeOrExpensesEnum.支出).OrderBy(x => x.ClassfyTypeId).ToList();
            return View("ClassIcon");
        }

        public IActionResult CreateIconModal(string Type, string Type2)
        {
            ViewBag.Type = "新增"+Type+"分類";
            ViewBag.Type2 = (IncomeOrExpensesEnum)Enum.Parse(typeof(IncomeOrExpensesEnum), Type2);
            ViewBag.IconList = _ITrackSpend_Services.GetIconList();
            ViewBag.IconTypeList = _ITrackSpend_Services.GetIconTypeList();

            return PartialView("_CreateIcon");
        }
        [HttpPost]
        public IActionResult CreateClassify([FromBody] ClassIconDTO DTO)
        {
            DTO.UserId = HttpContext.Session.GetObject<UserSessionDTO>("User").UserId;
            if (_ITrackSpend_Services.CreateClassifyInfo(DTO))
            {
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
        [HttpPost]
        public IActionResult CreateTrackSpend([FromBody] TrackSpendDTO DTO)
        {
            DTO.UserId = HttpContext.Session.GetObject<UserSessionDTO>("User").UserId;
            if (_ITrackSpend_Services.CreateTrackSpendInfo(DTO))
            {
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
    }
}
