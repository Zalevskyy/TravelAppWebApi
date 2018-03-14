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
    public class CommentController : ApiController
    {
        ITravelService travelService;
        public CommentController(ITravelService tService)
        {
            travelService = tService;
        }
        // GET: api/Comment
        public IEnumerable<CommentViewModel> GetUserComment(int idTrip)
        {
            string currentUser = RequestContext.Principal.Identity.Name;
            IEnumerable<CommentDTO> commentDTOs = travelService.GetUserCommentList(idTrip);
            Mapper.Initialize(cfg => cfg.CreateMap<CommentDTO, CommentViewModel>());
            var comments = Mapper.Map<IEnumerable<CommentDTO>, List<CommentViewModel>>(commentDTOs);
            return comments;
        }

        // GET: api/AllComment
        [Route("api/AllComments")]
        public IEnumerable<CommentViewModel> GetAllComment()
        {
            IEnumerable<CommentDTO> commentDTOs = travelService.GetAllCommentList();
            Mapper.Initialize(cfg => cfg.CreateMap<CommentDTO, CommentViewModel>());
            var comments = Mapper.Map<IEnumerable<CommentDTO>, List<CommentViewModel>>(commentDTOs);
            return comments;
        }
        // GET: api/Comment/5
        [ResponseType(typeof(CommentViewModel))]
        public IHttpActionResult GetComment(int id)
        {
            try
            {
                CommentDTO comentDTO = travelService.GetComment(id);
                Mapper.Initialize(cfg => cfg.CreateMap<CommentDTO, CommentViewModel>());
                var comment = Mapper.Map<CommentDTO, CommentViewModel>(comentDTO);
                return Ok(comment);
            }
            catch (ValidationException ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // POST: api/Comment
        [ResponseType(typeof(void))]
        public IHttpActionResult Post([FromBody]string text, [FromUri] int tripId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                travelService.AddCommentToTrip(text, tripId);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        // DELETE: api/Comment/5
        [ResponseType(typeof(void))]
        [Authorize(Roles = "admin")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                travelService.DeleteComment(id);
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
