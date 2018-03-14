using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelsApp.Models
{
    public class FotoViewModel
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int? TripId { get; set; }
    }
}