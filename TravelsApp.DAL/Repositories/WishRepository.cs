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
    public class WishRepository : IRepository<Wish>
    {
        private TravelsContext db;

        public WishRepository(TravelsContext db)
        {
            this.db = db;
        }

        public void Create(Wish item)
        {
            db.Wishes.Add(item);
        }

        public void Delete(int id)
        {
            Wish wish = db.Wishes.Find(id);
            if (wish != null)
                db.Wishes.Remove(wish);
        }

        public IEnumerable<Wish> Find(Func<Wish, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Wish Get(int id)
        {
            return db.Wishes.Find(id);
        }
        
        public IEnumerable<Wish> GetAll()
        {
            return db.Wishes;
        }

        public void Update(Wish item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
