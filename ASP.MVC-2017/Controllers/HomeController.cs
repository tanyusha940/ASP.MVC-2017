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
    [Authorize]
    public class HomeController : Controller
    { 
        
        public ActionResult Index()
        {
            return View();
        }
       
    }
}