using C_Web.Models;
using C_WebDTO.sysDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Dynamic;
using C_Web.Entity.SYS;
using C_WebDTO.SessionDTO;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using C_Web.Extension;
using C_Web.Extension.DBConn;
namespace C_Web.Controllers
{
    public static class Global
    {
        public static string DefalutDB = "DefaultConnectionString";
    }
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Login");
        }
        
        public IActionResult Logins(LoginDTO login)
        {
            if (ModelState.IsValid)
            {
                string connString = DBConnClass.GetDBConnString();
                string Sql = $"SELECT * FROM SYS_UserManager";
                using (var cn = new SqlConnection(connString))
                {
                    UserSessionDTO sessionDTO = new UserSessionDTO();
                    IQueryable<SYS_UserManager> adminManagers = cn.Query<SYS_UserManager>(Sql).AsQueryable();
                    if (adminManagers.Where(x => x.Account == login.Account && x.Password == login.Password).Count() > 0)
                    {
                        sessionDTO.Name = adminManagers.Select(x => x.AccountName).FirstOrDefault();
                        sessionDTO.account = adminManagers.Select(x => x.Account).FirstOrDefault();
                        sessionDTO.UserId = adminManagers.Select(x => x.UserId).FirstOrDefault();
                        HttpContext.Session.SetObject("User", sessionDTO);
                        HttpContext.Session.SetString("userName", sessionDTO.Name);
                        return RedirectToAction("Index", "Home", new { Area = "WebCAdmin" });
                    }
                    TempData["Message"] = "查無帳號資訊";
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View("Login");
            }
        }

    
    }
}
