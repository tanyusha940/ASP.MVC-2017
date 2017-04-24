using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.MVC_2017.Models.Entities
{
    public class Wall
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Text { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public Wall()
        {
            Comments = new List<Comment>();
        }
    }
}