using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BootFlixBC7.Models;

namespace BootFlixBC7.ViewModels
{
    public class ViewerFormViewModel
    {
        public Viewer Viewer {get; set;}
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}