using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelsApp.DAL.Entities
{
    public class Foto
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int TripId { get; set; }
        public Trip Trip { get; set; }

    }
}
