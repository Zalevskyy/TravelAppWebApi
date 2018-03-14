using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelsApp.DAL.Entities
{
    public class Trip
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTrip { get; set; }
        public string UserName { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Foto> Fotos { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
