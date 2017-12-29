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

            if (!DateTime.TryParseExact(stringValue, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime startDate)) {
                return new ValidationResult("Not in proper data format (yyyy-MM-dd).");
            }

            return ValidationResult.Success;
        }
    }

    public class IsPolicyDateValid : IsDateFormatted {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            base.IsValid(value, validationContext);

            string stringValue = value as string;

            if (!DateTime.TryParseExact(stringValue, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime startDate)) {
                return new ValidationResult("Not in proper data format (yyyy-MM-dd).");
            }

            TimeSpan delta = startDate - DateTime.Now;

            if (delta.TotalDays < -1 || delta.TotalDays > 60) {
                return new ValidationResult("Policy start date must be within 60 days from today's date.");
            }

            return ValidationResult.Success;
        }
    }
}