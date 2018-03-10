using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelsApp.DAL.Entities;

namespace TravelsApp.DAL
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public double GeoLat { get; set; }
        public double GeoLong { get; set; }
        public double Reiting { get; set; }
        public ICollection<Wish> Wishes { get; set; }
        public ICollection<Trip> Trips { get; set; }
    }
}
