using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootFlixBC7.Dtos
{
    public class WatchDto
    {
        public int ViewerId { get; set; }
        public List<int> SerieIds { get; set; }


    }
}