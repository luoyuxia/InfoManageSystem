using InfoManageSystem.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfoManageSystem.WebUI.Controllers
{
    public class CheckCodeController : Controller
    {
        // GET: CheckCode
        public ActionResult CheckCode()
        {
            //生成验证码
            ValidateCode validateCode = new ValidateCode();
            string code = validateCode.CreateValidateCode(4);
            Session["ValidateCode"] = code;
            byte[] bytes = validateCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }

        public bool CheckValidateCode(string num)
        {

            string cnum = Session["ValidateCode"] == null ? "" : Session["ValidateCode"].ToString();

            if (num == cnum && !string.IsNullOrEmpty(num))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}