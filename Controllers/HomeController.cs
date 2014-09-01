using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "ASP.NET MVC 5 app using Dapper for Data Daccess.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "If you need help!";

            return View();
        }
    }
}