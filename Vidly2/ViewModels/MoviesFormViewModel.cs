using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;
using Vidly2.Models;

namespace Vidly2.ViewModels
{
    public class MoviesFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter a valid name")]
        [StringLength(30)]
        public string Name { get; set; }

        public byte? GenreID { get; set; }//to represent the foreign key(should be the same type of the foreign key)

        [Required(ErrorMessage = "Realise date is needed to proceed")]
        public DateTime? ReleaseDate { get; set; }

        [GreaterThanActualDate]
        public DateTime? DateAdded { get; set; }

        [RegularExpression("^[1-9][0-9]*$", ErrorMessage = "the number of stock must be greater than 0")]
        public int? NumberInStock { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
    }
}