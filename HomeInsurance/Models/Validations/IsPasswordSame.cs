using System.ComponentModel.DataAnnotations;

namespace HomeInsurance.Models {

    public class IsPasswordSame : ValidationAttribute {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            NewUser newUser = (NewUser)validationContext.ObjectInstance;

            return (newUser.Password == newUser.ReEnterPassword) ? ValidationResult.Success 
                 : new ValidationResult("Must have matching passwords.");
        }
    }
}