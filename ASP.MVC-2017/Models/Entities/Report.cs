using System;

namespace ASP.MVC_2017.Models.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int? CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}