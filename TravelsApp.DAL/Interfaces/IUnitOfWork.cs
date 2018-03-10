using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelsApp.DAL.Entities;

namespace TravelsApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<City> Cities { get; }
        IRepository<Wish> Wishes { get; }
        IRepository<Trip> Trips { get; }
        IRepository<Foto> Fotos { get; }
        IRepository<Comment> Comments { get; }
        void Save();
    }
}
