using BootFlixBC7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootFlixBC7.ViewModels
{
    public class FavouriteViewModel
    {
        public Serie Serie { get; set; }
        public List<Viewer> Viewers { get; set; }
    }
}