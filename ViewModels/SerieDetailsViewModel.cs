using BootFlixBC7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootFlixBC7.ViewModels
{
    public class SerieDetailsViewModel
    {
        public Serie Serie { get; set; }
        public IEnumerable<Season> Seasons { get; set; }
    }
}