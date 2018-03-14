using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelsApp.Models
{
    public class TripViewModel
    {
        public int Id { get; set; }
        public DateTime DateTrip { get; set; }
        public string UserName { get; set; }
        public int CityId { get; set; }
    }
}