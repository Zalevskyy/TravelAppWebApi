using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using TravelsApp.BLL.DTO;
using TravelsApp.BLL.Interfaces;
using TravelsApp.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Http.Description;

namespace TravelsApp.Controllers
{
    [Authorize]
    public class TripController : ApiController
    {
        ITravelService travelService;
        public TripController(ITravelService tService)
        {
            travelService = tService;
        }
        // GET: api/Trip
        public IEnumerable<TripViewModel> GetTrips()
        {
            string currentUser = RequestContext.Principal.Identity.Name;
            IEnumerable<TripDTO> tripDTOs = travelService.GetUserTripList(currentUser);
            Mapper.Initialize(cfg => cfg.CreateMap<TripDTO, TripViewModel>());
            var trips = Mapper.Map<IEnumerable<TripDTO>, List<TripViewModel>>(tripDTOs);
            return trips;
        }

        // GET: api/Trip/5
        [ResponseType(typeof(TripViewModel))]
        public IHttpActionResult GetTrip(int id)
        {
            try
            {
                TripDTO tripDTO = travelService.GetTrip(id);
                Mapper.Initialize(cfg => cfg.CreateMap<TripDTO, TripViewModel>());
                var trip = Mapper.Map<TripDTO, TripViewModel>(tripDTO);
                return Ok(trip);
            }
            catch (ValidationException ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        // POST: api/Trip
        [ResponseType(typeof(void))]
        public IHttpActionResult PostTrip(WishViewModel wish, double reiting, DateTime dateTrip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //string currentUser = RequestContext.Principal.Identity.Name;
                Mapper.Initialize(cfg => cfg.CreateMap<WishViewModel, WishDTO>());
                var wishDTO = Mapper.Map<WishViewModel, WishDTO>(wish);
                travelService.AddTripReport(wishDTO, reiting, dateTrip);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            travelService.Dispose();
            base.Dispose(disposing);
        }
    }
}
