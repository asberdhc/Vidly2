using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly2.Models
{
    public class Min18YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.UNKNOWN ||
                customer.MembershipTypeId == MembershipType.PAY_AS_YOU_GO)
                return ValidationResult.Success;

            if (customer.Birthday == null)
                return new ValidationResult("birthay is required");

            var age = DateTime.Now.Year - customer.Birthday.Value.Year;

            return age >= 18 ? ValidationResult.Success : new ValidationResult("you must have at least 18 years olld to go on membership");
        }
    }
}