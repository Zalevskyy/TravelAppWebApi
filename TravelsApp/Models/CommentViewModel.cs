using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelsApp.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? TripId { get; set; }
    }
}