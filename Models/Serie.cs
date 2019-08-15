using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BootFlixBC7.Models
{
    public class Serie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        //[Required]
        //[DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        //[Required]
        //[DataType(DataType.Date)]
        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }

        
        public byte Seasons { get; set; }

        public byte GenreId { get; set; }
        public Genre Genre { get; set; }

        public bool IsAvailable { get; set; }

        public ICollection<Season> MySeasons { get; set; }

        //public Serie()
        //{
        //    DateAdded = DateTime.Now;
        //}
    }
}