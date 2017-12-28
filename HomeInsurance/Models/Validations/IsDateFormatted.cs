using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace HomeInsurance.Models {

    public class IsDateFormatted : ValidationAttribute {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
			string stringValue = value as string;

			if (string.IsNullOrWhiteSpace(stringValue))
                return new ValidationResult("This field cannot be empty.");

            stringValue.Trim();
            Regex regexCheck = new Regex("^[a-zA-Z_]+( [a-zA-Z_]+)*$");

            if (regexCheck.IsMatch(stringValue))
                return new ValidationResult("Numbers and dashes only.");
         
            if (!DateValidator(stringValue))
                return new ValidationResult("Not in proper data format (yyyy-MM-dd).");

            return ValidationResult.Success;
        }

        protected bool DateValidator(string value) {
            return DateTime.TryParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime parsed);
        }
    }
}