using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using InfoManageSystem.Domain.Entities;
using InfoManageSystem.Service.IService;
using Newtonsoft.Json;
using InfoManageSystem.Util;
using System.Drawing;
using System.IO;

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
        public ActionResult Login(string account, string password, bool encode = true)
        {
            string encodedPassword = password ;
            //如果要加密验证的话
            if (encode)
                 encodedPassword = MD5.encode(password);
            Employee e = userService.getEmployeeByAccount(account, encodedPassword);
            if(e!=null)
            {
                Employee employeeInfo = new Employee
                {
                    Avatar = e.Avatar,
                    Name = e.Name,
                    Account = e.Account,
                    Id = e.Id,
                    Password = e.Password,
                    Phone = e.Phone,
                    Role = e.Role,
                    BirthDay = e.BirthDay
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

        [Authorize]
        public ActionResult Management()
        {
            string userData = UserHelper.GetUserData();
            Employee e = JsonConvert.DeserializeObject<Employee>(userData);
            return View(e);
        }

        [Authorize]
        [HttpGet]
        public ActionResult PersonalInfo()
        {
            string userData = UserHelper.GetUserData();
            Employee e = JsonConvert.DeserializeObject<Employee>(userData);
            return View(e);
        }

        [Authorize]
        [HttpPost]
        public ActionResult PersonalInfo(Employee e)
        {
            if (userService.saveEmployee(e))
            {
                //不加密验证进行登录
                return Login(e.Account, e.Password,false);
            }
            else
                return RedirectToAction("Management");
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdatePassword(int Id,string account,string newPassword)
        {
            string encryptPassword = MD5.encode(newPassword);
            userService.updateEmployeePassword(Id, encryptPassword);
            return Login(account, newPassword);
        }

        [Authorize]
        [HttpPost]
        public ActionResult UploadImage(string img)
        {
            //图像解码
            byte[] images = Convert.FromBase64String(img.Split(',')[1]);
            //生成用户头像的标识
            string userData = UserHelper.GetUserData();
            Employee e = JsonConvert.DeserializeObject<Employee>(userData);
            string UploadImageFolder = AppDomain.CurrentDomain.BaseDirectory + "Content\\img\\";
            string imageId = e.Id + "_" + e.Name + DateTime.Now.ToLongTimeString() + ".png";
            imageId = imageId.Replace(':', '_');
            //保存图片
            MemoryStream stream = new MemoryStream(images);
            Image savedImage = Image.FromStream(stream);
            string filename = UploadImageFolder + imageId;
            savedImage.Save(filename);

            //更改用户的头像图片标识,并保存头像
            e.Avatar = imageId;
            userService.saveEmployee(e);
            return Login(e.Account, e.Password, false);
        }

        public ActionResult EasyUI()
        {
            return View();
        }
    }
}