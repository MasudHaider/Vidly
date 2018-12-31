using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter movie name")]
        [StringLength(255)]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Please select genre")]
        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Please select genre")]
        public byte GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required(ErrorMessage = "Release date is required")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Number In Stock")]
        [Required(ErrorMessage = "Please Enter Number of Movies That You Want")]
        [Range(1,20)]
        public byte NumberInStock { get; set; }
        
    }
}