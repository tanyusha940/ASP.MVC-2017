using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.MVC_2017.ViewModels
{
    public class CreateReportViewModels
    {
        public string Text { get; set; }
        public int CommentId { get; set; }
        public int WallId { get; set; }
        public string UserId { get; set; }
    }
}