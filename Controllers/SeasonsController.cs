using BootFlixBC7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootFlixBC7.Controllers
{
    public class SeasonsController : Controller
    {

        private ApplicationDbContext context;

        public SeasonsController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        //Get: Seasons/Details/id
        [Authorize(Roles = RoleName.CanManageSeries)]
        public ActionResult SeasonDetails(int id)
        {
            var season = context.Seasons.SingleOrDefault(se => se.Id == id);

            var episodes = context.Episodes.ToList();

            if (season == null)
                return HttpNotFound();

            return View(season);
        }

    }
}