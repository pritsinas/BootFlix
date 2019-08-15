using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BootFlixBC7.Models
{
    public class Watch
    {
        public int Id { get; set; }

        [Required]
        public int ViewerId { get; set;}

        public Viewer Viewer { get; set; }

        [Required]
        public int SerieId { get; set; }

        public Serie Serie { get; set; }

        public DateTime DateStarted { get; set; }
        public DateTime? DateCompleted { get; set; }

    }
}