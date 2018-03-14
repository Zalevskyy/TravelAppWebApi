using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelsApp.BLL.DTO;

namespace TravelsApp.BLL.Interfaces
{
    public interface ITravelService
    {
        void AddCityToWish(CityDTO city, string currentUser);
        void AddTripReport(WishDTO wish, double? reiting, DateTime date);
        void AddFotoToTrip(string path, int tripId);
        void AddCommentToTrip(string text, int tripId);
        WishDTO GetWish(int id);
        TripDTO GetTrip(int id);
        CommentDTO GetComment(int id);
        FotoDTO GetFoto(int id);
        IEnumerable<WishDTO> GetUserWishList(string currentUser);
        IEnumerable<TripDTO> GetUserTripList(string currentUser);
        IEnumerable<FotoDTO> GetUserFotoList(int tripId);
        IEnumerable<CommentDTO> GetUserCommentList(int tripId);
        IEnumerable<FotoDTO> GetAllFotoList();
        IEnumerable<CommentDTO> GetAllCommentList();
        void DeleteWish(int id);
        void DeleteFoto(int id);
        void DeleteComment(int id);
        void Dispose();
    }
}
