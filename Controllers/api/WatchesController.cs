using BootFlixBC7.Dtos;
using BootFlixBC7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BootFlixBC7.Controllers.api
{
    public class WatchesController : ApiController
    {
        private ApplicationDbContext context;

        public WatchesController()
        {
            context = new ApplicationDbContext();
        }

        
        [Authorize(Roles = RoleName.CanManageSeries)]
        [HttpPost]
        public IHttpActionResult CreateWatch(WatchDto watchDto)
        {
            var viewer = context.Viewers
                .SingleOrDefault(v => v.Id == watchDto.ViewerId);

            if (viewer == null)
                return BadRequest("Viewer is not Valid");

            var series = context.Series
                .Where(s => watchDto.SerieIds.Contains(s.Id)).ToList();

            if (series.Count != watchDto.SerieIds.Count)  //το api στέλνει 5 ids στη βάση βρίσκω 3
                return BadRequest("One or More Series is Invalid"); //(ex. κάποιος σβήνει Τη σειρά)

            foreach (var serie in series)
            {
                if (!serie.IsAvailable)
                    return BadRequest("Serie is not Available");

                var watch = new Watch()
                {
                    Viewer = viewer,
                    Serie = serie,
                    DateStarted = DateTime.Now
                };

                context.Watches.Add(watch);
            }
            context.SaveChanges();

            return Ok();
        }

    }
}
