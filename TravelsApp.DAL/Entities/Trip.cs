using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelsApp.DAL.Entities
{
    public class Trip
    {
        public int Id { get; set; }
        public DateTime DateTrip { get; set; }
        public string UserName { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public ICollection<Foto> Fotos { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
