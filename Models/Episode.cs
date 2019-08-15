using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BootFlixBC7.Models
{
    public class Episode
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public TimeSpan Duration { get; set; }

        [Required]
        public int SeasonId { get; set; }

        public Season Season { get; set; }


    }
}