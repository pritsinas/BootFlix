using BootFlixBC7.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BootFlixBC7.ViewModels
{
    public class SerieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Range(1, 20)]
        [Required]
        public byte? Seasons { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Serie" : "New Serie";
            }
        }

        public SerieFormViewModel()
        {
            Id = 0;
        }

        public SerieFormViewModel(Serie serie)
        {
            Id = serie.Id;
            Name = serie.Name;
            ReleaseDate = serie.ReleaseDate;
            Seasons = serie.Seasons;
            GenreId = serie.GenreId;
        }

    }
}