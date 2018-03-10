using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TravelsApp.DAL.Entities;

namespace TravelsApp.DAL.EF
{
    public class TravelsContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Wish> Wishes { get; set; }
        public DbSet<Foto> Fotos { get; set; }
        public DbSet<Comment> Comments { get; set; }


        public TravelsContext() : base("TravelContext") { }
    }
}
