using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Models.Validators
{
    public class ListingValidator : ValidationAttribute
    {
        public string GetErrorMessage() => "Listing can not expire before current date.";
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var expiresAt = ((DateTime)value);
            var now = DateTime.Now;

            if (expiresAt <= now)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
