using BootFlixBC7.Dtos;
using BootFlixBC7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using System.Data.Entity;

namespace BootFlixBC7.Controllers.api
{
    public class ViewersController : ApiController
    {
        private ApplicationDbContext context;

        public ViewersController()
        {
            context = new ApplicationDbContext(); 
        }

        //Get /api/viewers
        [Authorize(Roles = RoleName.CanManageViewers)]
        public IHttpActionResult GetViewers(string query = null)
        {
            var viewersQuery = context.Viewers
                .Include(v => v.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                viewersQuery = viewersQuery.Where(v => v.Name.Contains(query));
            
            var viewers = viewersQuery
                .ToList()
                .Select(Mapper.Map<Viewer, ViewerDto>);
         
            return Ok(viewers);
        }

        //GET /api/viewer/1
        [Authorize(Roles = RoleName.CanManageViewers)]
        public ViewerDto GetViewer(int id)
        {
            var viewer = context.Viewers.SingleOrDefault(v => v.Id == id);

            if (viewer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Viewer, ViewerDto>(viewer);
        }

        //POST /api/viewers
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageViewers)]
        public IHttpActionResult CreateViewer(ViewerDto viewerDto)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var viewer = Mapper.Map<ViewerDto, Viewer>(viewerDto);
            context.Viewers.Add(viewer);
            context.SaveChanges();

            viewerDto.Id = viewer.Id;

            return Created(new Uri(Request.RequestUri + "/" + viewer.Id), viewerDto);//by convention sto API επιστρέφεις created.
        }

        //PUT /api/viewers/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageViewers)]
        public void UpdateViewer(int id, ViewerDto viewerDto) //to id χρειαάζεται γιατί θa πάρω id από το routing.
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var viewerDb = context.Viewers.SingleOrDefault(v => v.Id == id);
            if (viewerDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            
            Mapper.Map(viewerDto, viewerDb);// Το DTO είναι η WHITELIST.

            ////WHITELIST
            //viewerDb.Name = viewer.Name;
            //viewerDb.BirthDate = viewer.BirthDate;
            //viewerDb.IsSubscribedToNewsLetter = viewer.IsSubscribedToNewsLetter;
            //viewerDb.MembershipTypeId = viewer.MembershipTypeId;

            context.SaveChanges();
        }

        //DELETE /api/viewers/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageViewers)]
        public void DeleteViewer(int id)
        {
            var viewerDb = context.Viewers.SingleOrDefault(v => v.Id == id);
            if (viewerDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            context.Viewers.Remove(viewerDb);
            context.SaveChanges();
        }
    }
}
