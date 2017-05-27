using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP.MVC_2017.Models.Repositories;
using System.Web.Mvc;
using ASP.MVC_2017.Models.Entities;
using ASP.MVC_2017.ViewModels;

namespace ASP.MVC_2017.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private readonly ReportRepository _reportRepository;

        public ReportController()
        {
            _reportRepository = new ReportRepository();
        }

        public ActionResult Index()
        {
            var reports = _reportRepository.GetReports();
            return View(reports);
        }

        [HttpPost]
        public ActionResult CreateReport(CreateReportViewModels model)
        {
            _reportRepository.CreateReport(model);
            return RedirectToAction("Index");
        }

        public ActionResult CreatingReport(int commentId)
        {
            ViewBag.CommentId = commentId;
            return View();
        }
    }
}