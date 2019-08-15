using BootFlixBC7.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using BootFlixBC7.ViewModels;
using System.Data.Entity;
using System.Linq;

namespace BootFlixBC7.Controllers
{
    public class SeriesController : Controller
    {
        private ApplicationDbContext context;

        public SeriesController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        //POST
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageSeries)]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Serie serie)
        {
            if (!ModelState.IsValid)
            {
                
                var viewModel = new SerieFormViewModel(serie)
                {
                    //Name = serie.Name,
                    //ReleaseDate = serie.ReleaseDate,
                    //Seasons = serie.Seasons,
                    //GenreId = serie.GenreId,
                    Genres = context.Genres.ToList()                    
                };
                return View("SerieForm", viewModel);
            }

            if (serie.Id == 0)
            {
                context.Series.Add(serie);
            }
            else
            {
                var serieDb = context.Series.Single(s => s.Id == serie.Id);
                serieDb.Name = serie.Name;               
                serieDb.ReleaseDate = serie.ReleaseDate;
                serieDb.Seasons = serie.Seasons;
                serieDb.GenreId = serie.GenreId;
                serieDb.Genre = serie.Genre;
            }
            context.SaveChanges();

            return RedirectToAction("Index", "Series"); 
        }

        //
        [Authorize(Roles = RoleName.CanManageSeries)]
        public ActionResult Edit(int id)
        {
            var serie = context.Series.SingleOrDefault(s => s.Id == id);
            var genres = context.Genres.ToList();

            if (serie == null)
                return HttpNotFound();
          
            var viewModel = new SerieFormViewModel(serie)
            {
                //Name = serie.Name,
                //ReleaseDate = serie.ReleaseDate,
                //Seasons = serie.Seasons,
                //GenreId = serie.GenreId,
                Genres = genres
            };

            return View("SerieForm", viewModel);
        }


        //Get
        [Authorize(Roles = RoleName.CanManageSeries)]
        public ActionResult New()
        { 
            var genres = context.Genres.ToList();
          
            var viewModel = new SerieFormViewModel
            {            
                //Name = serie.Name,
                //ReleaseDate = serie.ReleaseDate,
                //Seasons = serie.Seasons,
                //GenreId = serie.GenreId,
                Genres = genres
            };
    
            return View("SerieForm", viewModel);
        }

        // Series
        public ViewResult Index()
        {
            //var series = context.Series.Include(s => s.Genre).ToList();
            if (User.IsInRole(RoleName.CanManageSeries))
                return View("ListSeries");
           
            return View("ListSeriesReadOnly");
        }

        // Series/Details/id
        [Authorize(Roles = RoleName.CanManageSeries)]
        public ActionResult Details(int id)
        {
            var serieDetails = context.Series
                .Include(s => s.Genre)
                .SingleOrDefault(s => s.Id == id);

            var seasons = context.Seasons.ToList();

            if (serieDetails == null)
                return HttpNotFound();

            return View(serieDetails);
        }


        // GET: Series/Favourite
        public ViewResult Favourite()
        {
            var serie = new Serie()
            {
                Name = "Lost"
            };

            var viewers = new List<Viewer>
            {
                new Viewer { Name = "First Viewer" },
                new Viewer { Name = "Second Viewer" },
                new Viewer { Name = "Third Viewer" }
            };

            var favouriteViewModel = new FavouriteViewModel
            {
                Serie = serie,
                Viewers = viewers
            };

            return View(favouriteViewModel);
        }

        //// Series/Edit/6
        //public ActionResult Edit(int serieId)
        //{
        //    return Content("id= " + serieId);
        //}

        //private IEnumerable<Serie> GetSeries()
        //{
        //    return new List<Serie>
        //    {
        //        new Serie { Id = 1, Name = "Lost" },
        //        new Serie { Id = 2, Name = "Breaking Bad" },
        //        new Serie { Id = 2, Name = "Wire" }
        //    };
        //}

        //[Route("series/released/{year}/{month}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}
    }
}