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
    public class FotoController : ApiController
    {
        ITravelService travelService;
        public FotoController(ITravelService tService)
        {
            travelService = tService;
        }
        // GET: api/Foto
        public IEnumerable<FotoViewModel> GetUserFoto(int tripId)
        {
            //string currentUser = RequestContext.Principal.Identity.Name;
            IEnumerable<FotoDTO> fotoDTOs = travelService.GetUserFotoList(tripId);
            Mapper.Initialize(cfg => cfg.CreateMap<FotoDTO, FotoViewModel>());
            var fotos = Mapper.Map<IEnumerable<FotoDTO>, List<FotoViewModel>>(fotoDTOs);
            return fotos;
        }

        // GET: api/AllFoto
        [Route("api/AllFotos")]
        public IEnumerable<FotoViewModel> GetAllFoto()
        {
            IEnumerable<FotoDTO> fotoDTOs = travelService.GetAllFotoList();
            Mapper.Initialize(cfg => cfg.CreateMap<FotoDTO, FotoViewModel>());
            var fotos = Mapper.Map<IEnumerable<FotoDTO>, List<FotoViewModel>>(fotoDTOs);
            return fotos;
        }
        // GET: api/Foto/5
        [ResponseType(typeof(FotoViewModel))]
        public IHttpActionResult GetFoto(int id)
        {
            try
            {
                FotoDTO fotoDTO = travelService.GetFoto(id);
                Mapper.Initialize(cfg => cfg.CreateMap<FotoDTO, FotoViewModel>());
                var foto = Mapper.Map<FotoDTO, FotoViewModel>(fotoDTO);
                return Ok(foto);
            }
            catch (ValidationException ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // POST: api/Foto
        [ResponseType(typeof(void))]
        public IHttpActionResult Post([FromBody]string text, [FromUri] int tripId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                travelService.AddFotoToTrip(text, tripId);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        // DELETE: api/Foto/5
        [ResponseType(typeof(void))]
        [Authorize(Roles ="admin")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                travelService.DeleteFoto(id);
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
