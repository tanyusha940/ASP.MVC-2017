﻿using ASP.MVC_2017.Models;
using ASP.MVC_2017.Models.Entities;
using ASP.MVC_2017.Models.Repositories;
using ASP.MVC_2017.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ASP.MVC_2017.Controllers
{
    public class WallController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        private readonly WallRepository _wallRepository;

        public WallController()
        {
            _wallRepository = new WallRepository();
        }

        // GET: Wall
        public ActionResult Index()
        {
            var walls = _wallRepository.GetAllWalls();
            return View(walls);
        }
        [Authorize]
        public ActionResult GetUserWalls()
        {
            var walls = _wallRepository.GetUserWalls(User.Identity.GetUserId());
            return View(walls);
        }
        [Authorize]
        public ActionResult DeleteWall(int wallId)
        {
            _wallRepository.DeleteWall(wallId);
            return RedirectToAction("GetUserWalls", "Wall");
        }
        [Authorize]
        public ActionResult CreateWall()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult CreateWall(CreateWallViewModel model)
        {
            _wallRepository.CreateWall(model, User.Identity.GetUserId());
            return RedirectToAction("Index");
        }

    }
}