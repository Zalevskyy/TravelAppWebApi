using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using TravelsApp.DAL.EF;
using TravelsApp.DAL.Interfaces;

namespace TravelsApp.DAL.Repositories
{
    public class CityRepository : IRepository<City>
    {
        private TravelsContext db;
        public CityRepository(TravelsContext context)
        {
            this.db = context;
        }
        public void Create(City city)
        {
            db.Cities.Add(city);        
        }

        public void Delete(int id)
        {
            City city = db.Cities.Find(id);
            if (city != null)
                db.Cities.Remove(city);
        }

        public IEnumerable<City> Find(Func<City, bool> predicate)
        {
            return db.Cities.Include(c => c.Trips).Include(c => c.Wishes).Where(predicate).ToList();
        }

        public City Get(int id)
        {
            return db.Cities.Find(id);
        }

        public IEnumerable<City> GetAll()
        {
            return db.Cities;
        }

        public void Update(City city)
        {
            db.Entry(city).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
