using System.ComponentModel.DataAnnotations;

namespace HomeInsurance.Models {

    public class IsStringLengthBelow : StringLengthAttribute {

        public IsStringLengthBelow(int length) : base(length) {
            ErrorMessage = "{0} length should not be more than {1}.";
        }
    }
}