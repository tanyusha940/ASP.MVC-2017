using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ASP.MVC_2017.Models;
using ASP.MVC_2017.Models.Entities;
using Microsoft.AspNet.Identity;

namespace ASP.MVC_2017.Controllers
{
    public class HomeController : Controller
    { 
        ApplicationDbContext context = new ApplicationDbContext();
        public ActionResult Index()
        {
            var wall = context.Walls;
            return View(wall.ToList());
        }
        
        public ActionResult CreateWall()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateWall(string Title, string Text)
        {
            Wall wall_1 = new Wall
            {
                Title = Title,
                Text = Text,
                DateOfCreation = DateTime.Now,
                UserId = User.Identity.GetUserId()
            };
            context.Walls.Add(wall_1);
            context.SaveChanges();
            return RedirectToAction("Index");
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