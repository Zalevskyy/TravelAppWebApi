using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelsApp.BLL.DTO
{
    public class FotoDTO
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int? TripId { get; set; }
    }
}
