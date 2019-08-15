using BootFlixBC7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootFlixBC7.Controllers
{
    public class WatchesController : Controller
    {
        
        [Authorize(Roles = RoleName.CanManageSeries)]
        public ActionResult New()
        {
            return View();
        }
    }
}