using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelsApp.BLL.DTO
{
    public class TripDTO
    {
        public int Id { get; set; }
        public DateTime DateTrip { get; set; }
        public string UserName { get; set; }
        public int CityId { get; set; }
    }
}
