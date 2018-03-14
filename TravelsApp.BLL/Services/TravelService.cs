using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelsApp.BLL.DTO;
using TravelsApp.BLL.Interfaces;
using TravelsApp.DAL;
using TravelsApp.DAL.Entities;
using TravelsApp.DAL.Interfaces;

namespace TravelsApp.BLL.Services
{
    public class TravelService: ITravelService
    {
        IUnitOfWork Dbase { get; set; }
        public TravelService (IUnitOfWork unitOfWork)
        {
            Dbase = unitOfWork;
        }
        public void AddCityToWish(CityDTO cityDTO, string currentUser)
        {
            //чи вже є в базі місто з таким id?
            City city = Dbase.Cities.Get(cityDTO.Id);
            if (city == null)
            {
                //чи вже є в базі місто з цими координатами?
                city = Dbase.Cities.Find(c => Math.Abs(c.GeoLat - cityDTO.GeoLat) > 1 && Math.Abs(c.GeoLong - cityDTO.GeoLong) > 1).FirstOrDefault();
                if (city == null)
                {
                    //add city to DB
                    Mapper.Initialize(cfg => cfg.CreateMap<CityDTO, City>());
                    City newCity = Mapper.Map<CityDTO, City>(cityDTO);
                    Dbase.Cities.Create(newCity);
                    city = Dbase.Cities.Find(c => c.GeoLat == newCity.GeoLat && c.GeoLong == newCity.GeoLong).First();
                }
            }
            //add wish to DB
            Wish wish = new Wish
            {
                CityId = city.Id,
                UserName = currentUser
            };
            Dbase.Wishes.Create(wish);
            Dbase.Save();
        }
        public void AddTripReport (WishDTO wish, double? reiting, DateTime date)
        {
            Trip trip = new Trip
            {
                DateTrip = date,
                UserName = wish.UserName,
                CityId = wish.CityId
            };
            Dbase.Trips.Create(trip);
            //Change city reiting and counter
            City city = Dbase.Cities.Get(wish.CityId);
            if (reiting != null)
            {
                double? reitingOld = city.Reiting;
                int? countVisitors = city.CountVisitors;
                double? reitingNew = (reitingOld * countVisitors + reiting) / (countVisitors + 1);
                city.Reiting = reitingNew;
            }
            city.CountVisitors++;
            Dbase.Cities.Update(city);
        }
        public void AddFotoToTrip(string path, int tripId)
        {
            Foto foto = new Foto()
            {
                Path = path,
                TripId = tripId
            };
            Dbase.Fotos.Create(foto);
        }
        public void AddCommentToTrip(string text, int tripId)
        {
            Comment coment = new Comment()
            {
                Text = text,
                TripId = tripId
            };
            Dbase.Comments.Create(coment);
        }
        public WishDTO GetWish(int id)
        {
            Wish wish = Dbase.Wishes.Get(id);
            Mapper.Initialize(cfg => cfg.CreateMap<Wish, WishDTO>());
            return Mapper.Map<Wish, WishDTO>(wish);
        }
        public IEnumerable<WishDTO> GetUserWishList(string currentUser)
        {
            IEnumerable<Wish> wishes = Dbase.Wishes.GetAll();
            IEnumerable<Wish> userWishes = wishes.Where(w => Equals(w.UserName, currentUser)).ToList();
            Mapper.Initialize(cfg => cfg.CreateMap<Wish, WishDTO>());
            return Mapper.Map< IEnumerable < Wish >, IEnumerable<WishDTO>>(userWishes);
        }
        public IEnumerable<TripDTO> GetUserTripList(string currentUser)
        {
            IEnumerable<Trip> trips = Dbase.Trips.GetAll();
            IEnumerable<Trip> userTrips = trips.Where(t => Equals(t.UserName.ToUpper(), currentUser.ToUpper())).ToList();
            Mapper.Initialize(cfg => cfg.CreateMap<Trip, TripDTO>());
            return Mapper.Map<IEnumerable<Trip>, IEnumerable<TripDTO>>(userTrips);
        }
        public IEnumerable<FotoDTO> GetUserFotoList(int tripId)
        {
            IEnumerable<Foto> fotos = Dbase.Fotos.GetAll();
            IEnumerable<Foto> userFotos = fotos.Where(t => t.TripId==tripId).ToList();
            Mapper.Initialize(cfg => cfg.CreateMap<Foto, FotoDTO>());
            return Mapper.Map<IEnumerable<Foto>, IEnumerable<FotoDTO>>(userFotos);

        }
        public IEnumerable<CommentDTO> GetUserCommentList(int tripId)
        {
            IEnumerable<Comment> comments = Dbase.Comments.GetAll();
            IEnumerable<Comment> userComments = comments.Where(t => t.TripId == tripId).ToList();
            Mapper.Initialize(cfg => cfg.CreateMap<Comment, CommentDTO>());
            return Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDTO>>(userComments);
        }
        public IEnumerable<FotoDTO> GetAllFotoList()
        {
            IEnumerable<Foto> fotos = Dbase.Fotos.GetAll();
            Mapper.Initialize(cfg => cfg.CreateMap<Foto, FotoDTO>());
            return Mapper.Map<IEnumerable<Foto>, IEnumerable<FotoDTO>>(fotos);
        }
        public IEnumerable<CommentDTO> GetAllCommentList()
        {
            IEnumerable<Comment> comments = Dbase.Comments.GetAll();
            Mapper.Initialize(cfg => cfg.CreateMap<Comment, CommentDTO>());
            return Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDTO>>(comments);
        }
        public void DeleteWish (int id)
        {
            Dbase.Wishes.Delete(id);
            Dbase.Save();
        }
        //for role Admin
        public void DeleteFoto(int id)
        {
            Dbase.Fotos.Delete(id);
            Dbase.Save();
        }
        public void DeleteComment(int id)
        {
            Dbase.Comments.Delete(id);
            Dbase.Save();
        }
        public void Dispose()
        {
            Dbase.Dispose();
        }

        public TripDTO GetTrip(int id)
        {
            Trip trip = Dbase.Trips.Get(id);
            Mapper.Initialize(cfg => cfg.CreateMap<Trip, TripDTO>());
            return Mapper.Map<Trip, TripDTO>(trip);
        }

        public CommentDTO GetComment(int id)
        {
            Comment comment = Dbase.Comments.Get(id);
            Mapper.Initialize(cfg => cfg.CreateMap<Comment, CommentDTO>());
            return Mapper.Map<Comment, CommentDTO>(comment);
        }

        public FotoDTO GetFoto(int id)
        {
            Foto foto = Dbase.Fotos.Get(id);
            Mapper.Initialize(cfg => cfg.CreateMap<Foto, FotoDTO>());
            return Mapper.Map<Foto, FotoDTO>(foto);
        }


    }
}
