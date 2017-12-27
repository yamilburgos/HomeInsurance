using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace HomeInsurance.Models {

    public class IsNumeric : ValidationAttribute {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            string stringValue = (value as string).Trim();

            if (string.IsNullOrWhiteSpace(stringValue))
                return new ValidationResult("This field cannot be empty.");

            Regex regexCheck = new Regex("^[0-9_]+( [0-9_]+)*$");

            if (!regexCheck.IsMatch(stringValue))
                return new ValidationResult("Numbers only.");

            return ValidationResult.Success;
        }
    }
}