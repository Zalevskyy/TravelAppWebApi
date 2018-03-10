using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using TravelsApp.DAL.EF;
using TravelsApp.DAL.Entities;
using TravelsApp.DAL.Interfaces;

namespace TravelsApp.DAL.Repositories
{
    class TripRepository : IRepository<Trip>
    {
        private TravelsContext db;

        public TripRepository(TravelsContext db)
        {
            this.db = db;
        }

        public void Create(Trip item)
        {
            db.Trips.Add(item);
        }

        public void Delete(int id)
        {
            Trip trip = db.Trips.Find(id);
            if (trip != null)
                db.Trips.Remove(trip);
        }

        public IEnumerable<Trip> Find(Func<Trip, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Trip Get(int id)
        {
            return db.Trips.Find(id);
        }

        public IEnumerable<Trip> GetAll()
        {
            return db.Trips;
        }

        public void Update(Trip item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
