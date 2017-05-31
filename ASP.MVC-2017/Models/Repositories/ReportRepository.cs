using ASP.MVC_2017.Models;
using ASP.MVC_2017.Models.Entities;
using ASP.MVC_2017.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ASP.MVC_2017.Models.Repositories
{
    public class ReportRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public List<Report> GetReports()
        {
            return context.Reports.ToList();
        }

        public void CreateReport(CreateReportViewModels model)
        {
            var comment = context.Comments.Where(c => c.Id == model.CommentId).FirstOrDefault();
            if (comment != null)
            {
                var wall = context.Walls.Where(w => w.Id == comment.WallId).FirstOrDefault();
                if (wall != null)
                {
                    Report report = new Report
                    {
                        CommentId = model.CommentId,
                        UserId = model.UserId,
                        Date = DateTime.Now,
                        Text = model.Text
                    };
                    context.Reports.Add(report);
                    context.SaveChanges();
                }
            }
        }
    }
}