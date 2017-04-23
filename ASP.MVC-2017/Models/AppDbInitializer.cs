using ASP.MVC_2017.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASP.MVC_2017.Models
{
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser { Email = "fuck@off.com", UserName = "fuck@off.com", Id = "ba47eb41-7d0a-4012-8023-4418ced312c3", EmailConfirmed = true, RegistrationDate = DateTime.Now.AddMonths(-1), NumberOfWalls =1, NumberOfComments =4 };
            string password = "Qwerty_1234";
            var result = userManager.Create(user, password);

            Wall wall_1 = new Wall
            {
                Id = 1,
                Title = "Title_1",
                Text = "Text_1",
                DateOfCreation = DateTime.Now.AddDays(-1),
                ApplicationUserId = "ba47eb41-7d0a-4012-8023-4418ced312c3"
            };
            Wall wall_2 = new Wall
            {
                Id = 2,
                Title = "Title_2",
                Text = "Text_2",
                DateOfCreation = DateTime.Now,
                ApplicationUserId = "ba47eb41-7d0a-4012-8023-4418ced312c3"
            };
            Wall wall_3 = new Wall
            {
                Id = 3,
                Title = "Title_3",
                Text = "Text_3",
                DateOfCreation = DateTime.Now.AddHours(-1),
                ApplicationUserId = "ba47eb41-7d0a-4012-8023-4418ced312c3"
            };
            Comment comment_1 = new Comment
            {
                Id = 1,
                CommentDate = DateTime.Now,
                CommentText = "XUI",
                ApplicationUserId = "ba47eb41-7d0a-4012-8023-4418ced312c3",
                WallId = 1
            };
            context.Comments.Add(comment_1);
            wall_1.Comments.Add(comment_1);
            context.Walls.Add(wall_1);
            context.Walls.Add(wall_2);
            context.Walls.Add(wall_3);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}