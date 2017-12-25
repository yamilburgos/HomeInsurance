using System.ComponentModel.DataAnnotations;

namespace HomeInsurance.Models {

    public class IsPasswordSame : ValidationAttribute {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            Login login = (Login)validationContext.ObjectInstance;

            return (login.Password == login.ReEnterPassword) ? ValidationResult.Success 
                 : new ValidationResult("Must have matching passwords.");
        }
    }
}