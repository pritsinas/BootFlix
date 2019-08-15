using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BootFlixBC7.Models
{
    public class Genre
    {
        public byte Id { get; set; }                
        public string Name { get; set; }

        public ICollection<Serie> Series { get; set; }
    }
}