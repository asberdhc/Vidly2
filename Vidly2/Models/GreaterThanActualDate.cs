using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;
using Vidly2.Dtos;

namespace Vidly2.Models
{
    public class GreaterThanActualDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Movie movie = (Movie)validationContext.ObjectInstance;
            if (movie.DateAdded > DateTime.Now)
                return ValidationResult.Success;

            return new ValidationResult("Must be greater than the current date");
        }
    }
}