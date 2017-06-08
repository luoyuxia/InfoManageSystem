using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Newtonsoft.Json;
namespace InfoManageSystem.WebUI.Controllers
{
    public class UserHelper
    {
        public static string GetUserData()
        {
            if(HttpContext.Current.User.Identity.IsAuthenticated)
            {
                FormsIdentity id = HttpContext.Current.User.Identity as FormsIdentity;
                FormsAuthenticationTicket ticket = id.Ticket;
                string userInfo = id.Ticket.UserData;
                return userInfo;
            }
            return "";
        }

   /*     public static bool SetUserData(string userData)
        {
            if(HttpContext.Current.User.Identity.IsAuthenticated)
            {
                FormsIdentity id = HttpContext.Current.User.Identity as FormsIdentity;
                FormsAuthenticationTicket ticket = id.Ticket;
                ticket.UserData  = 
            }
        }*/
    }
}