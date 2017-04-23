using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.MVC_2017.Models.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentText { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int? WallId { get; set; }
        public Wall Wall { get; set; }
    }
}