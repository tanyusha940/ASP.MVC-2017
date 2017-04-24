using ASP.MVC_2017.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace ASP.MVC_2017.Models
{
    public class AppDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем две роли
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };

            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);

            // создаем пользователей
            var user = new ApplicationUser { Email = "fuck@off.com", UserName = "fuck", Id = "ba47eb41-7d0a-4012-8023-4418ced312c3", EmailConfirmed = true, RegistrationDate = DateTime.Now.AddMonths(-1), NumberOfWalls = 1, NumberOfComments = 4 };
            string password = "Qwerty_1234";
            var result = userManager.Create(user, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(user.Id, role1.Name);
                userManager.AddToRole(user.Id, role2.Name);
            }          

            Wall wall_1 = new Wall
            {
                Id = 1,
                Title = "Title_1",
                Text = "Text_1",
                DateOfCreation = DateTime.Now.AddDays(-1),
                UserId = "ba47eb41-7d0a-4012-8023-4418ced312c3"
            };
            Wall wall_2 = new Wall
            {
                Id = 2,
                Title = "Title_2",
                Text = "Text_2",
                DateOfCreation = DateTime.Now,
                UserId = "ba47eb41-7d0a-4012-8023-4418ced312c3"
            };
            Wall wall_3 = new Wall
            {
                Id = 3,
                Title = "Title_3",
                Text = "Text_3",
                DateOfCreation = DateTime.Now.AddHours(-1),
                UserId = "ba47eb41-7d0a-4012-8023-4418ced312c3"
            };
            context.Walls.Add(wall_1);
            context.Walls.Add(wall_2);
            context.Walls.Add(wall_3);
            Comment comment_1 = new Comment
            {
                Id = 1,
                Date = DateTime.Now,
                Value = "XUI",
                UserId = "ba47eb41-7d0a-4012-8023-4418ced312c3",
                WallId = 1
            };
            context.Comments.Add(comment_1);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}