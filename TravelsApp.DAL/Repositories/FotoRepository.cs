using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelsApp.DAL.EF;
using TravelsApp.DAL.Entities;
using TravelsApp.DAL.Interfaces;

namespace TravelsApp.DAL.Repositories
{
    class FotoRepository : IRepository<Foto>
    {
        private TravelsContext db;

        public FotoRepository(TravelsContext db)
        {
            this.db = db;
        }

        public void Create(Foto item)
        {
            db.Fotos.Add(item);
        }

        public void Delete(int id)
        {
            Foto  foto = db.Fotos.Find(id);
            if (foto != null)
                db.Fotos.Remove(foto);
        }

        public IEnumerable<Foto> Find(Func<Foto, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Foto Get(int id)
        {
            return db.Fotos.Find(id);
        }

        public IEnumerable<Foto> GetAll()
        {
            return db.Fotos;
        }

        public void Update(Foto item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
