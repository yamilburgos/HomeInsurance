using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace HomeInsurance.Models {

    public class IsAlphanumeric : ValidationAttribute {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            if(value == null)
                return new ValidationResult("This field cannot be empty.");
            if (string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult("This field cannot be empty.");

            Regex regexCheck = new Regex("^[a-zA-Z0-9_]+( [a-zA-Z0-9_]+)*$");
            if (!regexCheck.IsMatch(value.ToString()))
                return new ValidationResult("Only Alphabets and Numbers allowed.");

            return ValidationResult.Success;
        }
    }
}