using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;
using ASP.MVC_2017.Models;

namespace ASP.MVC_2017.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext a = new ApplicationDbContext();
        public ActionResult Index()
        {
            var wall = a.Walls;
            return View(wall.ToList());
        }
        [Authorize(Roles = "admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}