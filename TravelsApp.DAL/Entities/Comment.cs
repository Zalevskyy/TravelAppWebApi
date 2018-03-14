using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelsApp.DAL.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        [ForeignKey("Trip")]
        public int? TripId { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
