using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace HomeInsurance.Models {

    public class IsAddressLineTwo : ValidationAttribute {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            string stringValue = (value as string).Trim();

			if (string.IsNullOrWhiteSpace(stringValue)) return ValidationResult.Success;

            Regex regexCheck = new Regex("^[a-zA-Z0-9_]+( [a-zA-Z0-9_]+)*$");

            if (!regexCheck.IsMatch(stringValue))
                return new ValidationResult("Alphabets and Numbers only.");

            return ValidationResult.Success;
        }
    }
}