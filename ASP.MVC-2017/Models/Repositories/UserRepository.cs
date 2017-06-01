using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.MVC_2017.Models.Repositories
{
    public class UserRepository : IDisposable
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

        public void UpdateUser(ApplicationUser user)
        {
            var oldUser = context.Users.Where(u => u.Id == user.Id).FirstOrDefault();
            if(oldUser != null)
            {
                oldUser.ImageData = user.ImageData;
                oldUser.ImageMimeType = user.ImageMimeType;
                context.SaveChanges();
            }
        }

        public IndexViewModel GetUserInformation(string userId)
        {
            var user = GetUser(userId);
            IndexViewModel userInformation = new IndexViewModel()
            {
                RegistrationDate = user.RegistrationDate,
                NumberOfComments = context.Comments.Where(c => c.UserId == user.Id).Count(),
                NumberOfWalls = context.Walls.Where(w => w.UserId == user.Id).Count(),
                Name = user.Name,
                SurName = user.SurName,
                Email = user.Email,
                ImageData = user.ImageData,
                ImageMimeType = user.ImageMimeType
            };
            return userInformation;
        }

        public ApplicationUser GetUser(string userId)
        {
            return context.Users.Where(u => u.Id == userId).FirstOrDefault();
        }
    }
}