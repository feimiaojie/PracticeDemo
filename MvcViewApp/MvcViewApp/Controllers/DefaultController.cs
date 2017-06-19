using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcViewApp.Controllers
{
    public class User
    {
        public string Name { get; set; }
    }
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            ViewData["One"] = "view data";
            ViewBag.Two = "view bag";
            var _user = new User() { Name="lixuhuan"};
            TempData["Four"] = "template data";
            return View(_user);
        }

        public ActionResult Index2()
        {
            return View();
        }
    }
}