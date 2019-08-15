using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BootFlixBC7.Models
{
    public class Season
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string SeasonName { get; set; }
        
        [Required]
        public int SerieId { get; set; }

        public Serie Serie { get; set; }

        public ICollection<Episode> Episodes { get; set; }
    }
}