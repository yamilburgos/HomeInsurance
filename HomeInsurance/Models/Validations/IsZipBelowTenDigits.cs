using System.ComponentModel.DataAnnotations;

namespace HomeInsurance.Models {

    public class IsZipBelowTenDigits : ValidationAttribute {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
                if (value == null) return new ValidationResult("This field cannot be empty.");

                string stringValue = value.ToString();

                if (string.IsNullOrEmpty(stringValue))
                    return new ValidationResult("This field cannot be empty.");
                if (stringValue.Length > 9)
                    return new ValidationResult("Zip Code is too high.");

                return ValidationResult.Success;
        }
    }
}