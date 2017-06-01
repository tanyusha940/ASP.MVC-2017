using ASP.MVC_2017.Helpers;
using ASP.MVC_2017.Models.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.MVC_2017.Controllers
{
    public class UserController : Controller
    {
        UploadImageHelper imgHelper = new UploadImageHelper();
        private readonly UserRepository _userRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddAvatar(HttpPostedFileBase Image)
        {
            var user = _userRepository.GetUser(User.Identity.GetUserId());
            if (Image != null)
            {
                user.ImageMimeType = Image.ContentType;
                user.ImageData = new byte[Image.ContentLength];
                Image.InputStream.Read(user.ImageData, 0, Image.ContentLength);
                _userRepository.UpdateUser(user);
            }
            return RedirectToAction("Index", "Manage", new { });
        }

        public FileContentResult GetImage()
        {
            var user = _userRepository.GetUser(User.Identity.GetUserId());

            if (user != null)
            {
                return File(user.ImageData, user.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

    }
}