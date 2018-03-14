using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using TravelsApp.BLL.DTO;
using TravelsApp.BLL.Interfaces;
using TravelsApp.Models;
using System.ComponentModel.DataAnnotations;

namespace TravelsApp.Controllers
{
    [Authorize]
    public class WishController : ApiController
    {
        ITravelService travelService;
        public WishController(ITravelService tService)
        {
            travelService = tService;
        }
        // GET: api/Wish
        public IEnumerable<WishViewModel> GetWishes()
        {
            string currentUser = RequestContext.Principal.Identity.Name;
            IEnumerable<WishDTO> wishDTOs = travelService.GetUserWishList(currentUser);
            Mapper.Initialize(cfg => cfg.CreateMap<WishDTO, WishViewModel>());
            var wishes = Mapper.Map<IEnumerable<WishDTO>, List<WishViewModel>>(wishDTOs);
            return wishes;
        }

        // GET: api/Wish/5
        [ResponseType(typeof(WishViewModel))]
        public IHttpActionResult GetWish(int id)
        {
            try
            {
                WishDTO wishDTO = travelService.GetWish(id);
                Mapper.Initialize(cfg => cfg.CreateMap<WishDTO, WishViewModel>());
                var wish = Mapper.Map<WishDTO, WishViewModel>(wishDTO);
                return Ok(wish);
            }
            catch (ValidationException ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // POST: api/Wish
        [ResponseType(typeof(void))]
        public IHttpActionResult PostWish(CityViewModel city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                string currentUser = RequestContext.Principal.Identity.Name;
                Mapper.Initialize(cfg => cfg.CreateMap<CityViewModel, CityDTO>());
                var cityDTO = Mapper.Map<CityViewModel, CityDTO>(city);
                travelService.AddCityToWish(cityDTO, currentUser);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // DELETE: api/Wish/5
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteWish(int id)
        {
            try
            {
                travelService.DeleteWish(id);
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