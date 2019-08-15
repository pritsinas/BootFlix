using BootFlixBC7.Models;
using BootFlixBC7.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System;

namespace BootFlixBC7.Controllers
{
    //[Authorize]
    public class ViewersController : Controller
    {
        private ApplicationDbContext context; 

        public ViewersController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        //GET
        [Authorize(Roles = RoleName.CanManageViewers)]
        public ActionResult Edit (int id)
        {
            var viewer = context.Viewers.SingleOrDefault(v => v.Id == id);

            if (viewer == null)
                return HttpNotFound();

            var viewModel = new ViewerFormViewModel
            {
                Viewer = viewer,
                MembershipTypes = context.MembershipTypes.ToList()
            };

            return View("ViewerForm", viewModel);
        }

        //POST (ΚΑΝΕΙ CREATE KAI EDIT)
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageViewers)]
        [ValidateAntiForgeryToken] // Συγκρίνει το cookie Με το Τoken.
        public ActionResult Save(Viewer viewer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new ViewerFormViewModel()
                {
                    Viewer = viewer,
                    MembershipTypes = context.MembershipTypes.ToList()
                };

                return View("ViewerForm", viewModel);
            }

            if (viewer.Id == 0) // Create Viewer
            {
                context.Viewers.Add(viewer);
            }
            else //Edit Viewer
            {   // ΑΝΤΙ ΤΗΣ WHITELIST στο BootCampApp EDIT POST.
                var viewerDb = context.Viewers.Single(v => v.Id == viewer.Id);
                viewerDb.Name = viewer.Name;
                viewerDb.BirthDate = viewer.BirthDate;
                viewerDb.IsSubscribedToNewsLetter = viewer.IsSubscribedToNewsLetter;
                viewerDb.MembershipTypeId = viewer.MembershipTypeId;
            }
            context.SaveChanges();

            return RedirectToAction("Index", "Viewers");
        }

        //GET
        [Authorize(Roles = RoleName.CanManageViewers)]
        public ActionResult New()
        {
            var membershipTypes = context.MembershipTypes.ToList();
            var viewModel = new ViewerFormViewModel()
            {
                Viewer = new Viewer(),
                MembershipTypes = membershipTypes
            };

            return View("ViewerForm", viewModel);
        }

        //// GET: Viewers
        //public ActionResult Index()
        //{
        //    var viewers = context.Viewers
        //        .Include(v => v.MembershipType)
        //        .ToList();

        //    return View(viewers);
        //}

        
        public ActionResult Index()
        {
            //if (User.IsInRole(RoleName.CanManageViewers))
                return View("ListViewers");

            //return View("ListViewersReadonly");
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageViewers)]
        public ActionResult Details(int id)
        {
            var viewer = context.Viewers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (viewer == null)
                return HttpNotFound();

            return View(viewer);
        }

        //private IEnumerable<Viewer> GetViewers()
        //{
        //    return new List<Viewer>
        //    {
        //        new Viewer { Id = 1, Name = "Peri Aidino" },
        //        new Viewer { Id = 2, Name = "George Anastasiadis" },
        //        new Viewer { Id = 3, Name = "Aggelos Galatas" }
        //    };
        //}
    }
}