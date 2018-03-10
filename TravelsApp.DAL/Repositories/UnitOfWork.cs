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
    class UnitOfWork : IUnitOfWork
    {
        private TravelsContext db = new TravelsContext();
        private CityRepository cityRepository;
        private CommentRepository comentRepository;
        private WishRepository wishRepository;
        private TripRepository tripRepository;
        private FotoRepository fotoRepository;
        public IRepository<City> Cities
        {
            get
            {
                if (cityRepository == null)
                    cityRepository = new CityRepository(db);
                return cityRepository;
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                if (comentRepository == null)
                    comentRepository = new CommentRepository(db);
                return comentRepository;
            }
        }

        public IRepository<Foto> Fotos
        {
            get
            {
                if (fotoRepository == null)
                    fotoRepository = new FotoRepository(db);
                return fotoRepository;
            }
        }

        public IRepository<Trip> Trips
        {
            get
            {
                if (tripRepository == null)
                    tripRepository = new TripRepository(db);
                return tripRepository;
            }
        }

        public IRepository<Wish> Wishes
        {
            get
            {
                if (wishRepository == null)
                    wishRepository = new WishRepository(db);
                return wishRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; 

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
