using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.Dtos
{
    public class MovieDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter a valid name")]
        [StringLength(30)]
        public string Name { get; set; }

        public byte GenreID { get; set; }//to represent the foreign key(should be the same type of the foreign key)
        public GenreDTO Genre { get; set; }

        [Required(ErrorMessage = "Realise date is needed to proceed")]
        public DateTime ReleaseDate { get; set; }

        //[GreaterThanActualDate]
        [Required]
        public DateTime DateAdded { get; set; }

        [RegularExpression("^[1-9][0-9]*$", ErrorMessage = "the number of stock must be greater than 0")]
        public int NumberInStock { get; set; }
    }
}