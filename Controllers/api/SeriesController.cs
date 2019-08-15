
using AutoMapper;
using BootFlixBC7.Dtos;
using BootFlixBC7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace BootFlixBC7.Controllers.api
{
    public class SeriesController : ApiController
    {
        private ApplicationDbContext context;

        public SeriesController()
        {
            context = new ApplicationDbContext();
        }

        //GET /api/series
        [Authorize(Roles = RoleName.CanManageSeries)]
        public IEnumerable<SerieDto> GetSeries(string query = null)
        {
            var seriesQuery = context.Series
                .Include(s => s.Genre)
                .Where(s => s.IsAvailable);

            if (!String.IsNullOrWhiteSpace(query))
                seriesQuery = seriesQuery.Where(m => m.Name.Contains(query));

            return seriesQuery
                .ToList()
                .Select(Mapper.Map<Serie, SerieDto>);             
        }

        //GET /api/series/1
        [Authorize(Roles = RoleName.CanManageSeries)]
        public SerieDto GetSerie(int id)
        {
            var serie = context.Series.Include(s => s.Genre).SingleOrDefault(s => s.Id == id);

            if (serie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Serie, SerieDto>(serie);
        }

        //POST /api/series
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageSeries)]
        public IHttpActionResult CreateSerie(SerieDto serieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var serie = Mapper.Map<SerieDto, Serie>(serieDto);
            context.Series.Add(serie);
            context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + serie.Id), serieDto);
        }

        //PUT /api/series/id
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageSeries)]
        public void UpdateSerie(int id, SerieDto serieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var serieDb = context.Series.Include(s => s.Genre).SingleOrDefault(s => s.Id == id);
            if (serieDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(serieDto, serieDb);
            context.SaveChanges();
        }

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageSeries)]
        public void DeleteSerie(int id)
        {
            var serieDb = context.Series.SingleOrDefault(s => s.Id == id);
            if (serieDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            context.Series.Remove(serieDb);
            context.SaveChanges();
        }
    }
}
