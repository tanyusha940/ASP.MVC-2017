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
    public class WallRepository : IDisposable
    {
        ApplicationDbContext context = new ApplicationDbContext();

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public List<Wall> GetAllWalls()
        {
            return context.Walls.ToList();
        }

        public List<Wall> GetUserWalls(string userId)
        {
            return context.Walls.Where(w => w.UserId == userId).ToList();
        }

        public void DeleteWall(int id)
        {
            var wall = context.Walls.Where(w => w.Id == id).FirstOrDefault();
            if (wall != null)
            {
                context.Walls.Remove(wall);
                context.SaveChanges();
            }
        }
        
        public void CreateWall(CreateWallViewModel model, string userId)
        {
            Wall wall_1 = new Wall
            {
                Title = model.Title,
                Text = model.Text,
                DateOfCreation = DateTime.Now,
                UserId = userId
            };
            context.Walls.Add(wall_1);
            context.SaveChanges();
        }

        public void AddComment(string value, string userId, int wallId)
        {
            var wall = context.Walls.Where(w => w.Id == wallId).FirstOrDefault();
            if(wall != null)
            {
                Comment comment = new Comment
                {
                    Date = DateTime.Now,
                    UserId = userId,
                    Value = value
                };

                wall.Comments.Add(comment);
                context.SaveChanges();
            }
           
        }
        
        //public async Task<IActionResult> Index(SortState sortOrder = SortState.CommentsAsc)
        //{
        //    IQueryable<Wall> walls = context.Walls.Include(x => x.Model);
        //    ViewData["CommentSort"] = sortOrder == SortState.CommentsAsc ? SortState.CommentsDesc : SortState.CommentsAsc;
        //    ViewData["DataSort"] = sortOrder == SortState.DateAsc ? SortState.DateDesc : SortState.DateAsc;

        //    switch (sortOrder)
        //    {
        //        case SortState.CommentsDesc:
        //            walls =walls.OrderByDescending(s => s.Comments);
        //            break;
        //        case SortState.CommentsAsc:
        //            walls = walls.OrderBy(s => s.Comments);
        //            break;
        //        case SortState.DateDesc:
        //            walls = walls.OrderByDescending(s => s.DateOfCreation);
        //            break;
        //        case SortState.DateAsc:
        //            walls = walls.OrderBy(s => s.DateOfCreation);
        //            break;

        //    return View(await walls.AsNoTracking().ToListAsync());
        //}
    //}


    }
}