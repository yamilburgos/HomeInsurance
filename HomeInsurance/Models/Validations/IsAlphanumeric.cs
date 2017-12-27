using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace HomeInsurance.Models {

    public class IsAlphanumeric : ValidationAttribute {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
			string stringValue = value as string;

			if (string.IsNullOrEmpty(stringValue))
                return new ValidationResult("This field cannot be empty.");

            Regex regexCheck = new Regex("^[a-zA-Z0-9_]+( [a-zA-Z0-9_]+)*$");

            if (!regexCheck.IsMatch(stringValue))
                return new ValidationResult("Alphabets and Numbers only.");

            return ValidationResult.Success;
        }
    }
}