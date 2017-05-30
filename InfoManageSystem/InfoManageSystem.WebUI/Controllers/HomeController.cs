using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using InfoManageSystem.Domain.Entities;
using InfoManageSystem.Service.IService;
using Newtonsoft.Json;

namespace InfoManageSystem.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View("login");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Login(string account,string password)
        {
            Employee e = userService.getEmployeeByAccount(account, password);
            if(e!=null)
            {
                Employee employeeInfo  = new Employee
                {
                    Avatar = e.Avatar,
                    Name = e.Name
                };
                string userInfo = JsonConvert.SerializeObject(employeeInfo);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, account,
                    DateTime.Now, DateTime.Now.AddMinutes(30), true, userInfo, FormsAuthentication.FormsCookiePath);
                string encTicket = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);
                return RedirectToAction("Management");
            }
            return RedirectToAction("Index",new { error = true });
        }

        public ActionResult Management()
        {
            string userData = UserHelper.GetUserData();
            Employee e = JsonConvert.DeserializeObject<Employee>(userData);
            ViewBag.username = e.Name;
            ViewBag.Avatar = e.Avatar;
            return View();
        }

        public ActionResult PersonalInfo()
        {
            return View();
        }

        public ActionResult EasyUI()
        {
            return View();
        }
    }
}