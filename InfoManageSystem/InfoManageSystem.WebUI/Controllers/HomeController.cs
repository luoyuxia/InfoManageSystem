using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InfoManageSystem.Domain.Entities;
using InfoManageSystem.Domain.Abstract;

namespace InfoManageSystem.WebUI.Controllers
{
    public class HomeController : Controller
    {
  //      private IProductsRepository productsRepository;

        public HomeController()
        {
        }
        // GET: Home
        public ActionResult Index()
        {
            //      return View(productsRepository.Products);
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