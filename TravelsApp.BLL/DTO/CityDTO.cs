using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelsApp.BLL.DTO
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public double GeoLat { get; set; }
        public double GeoLong { get; set; }
        public double Reiting { get; set; }
    }
}
