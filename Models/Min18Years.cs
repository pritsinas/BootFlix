using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BootFlixBC7.Models
{
    public class Min18Years : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var viewer = (Viewer)validationContext.ObjectInstance;

            if (viewer.MembershipTypeId == MembershipType.Free)
                return ValidationResult.Success;

            if (viewer.BirthDate == null)
                return new ValidationResult("Birthdate Is Required");

            var age = DateTime.Today.Year - viewer.BirthDate.Value.Year;

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Viewer Must Be at least 18 Years Old");
        }
    }
}