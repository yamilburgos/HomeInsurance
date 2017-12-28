using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeInsurance.Models {

    public class Homeowner {

		public int Id { get; set; }

		[ForeignKey("User")]
		public int UserId { get; set; }

		[Required]
		[IsStringLengthBelow(30)]
        [IsAlphanumeric]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Required]
		[IsStringLengthBelow(30)]
        [IsAlphanumeric]
        [Display(Name = "Last Name")]
		public string LastName { get; set; }

		[Required]
		[IsStringLengthBelow(10)]
        [IsDateFormatted]
		[Display(Name = "Date of Birth")]
		public string DOB { get; set; }

		[Required]
		[Display(Name = "Are you retired?")]
		public bool IsRetired { get; set; }

		[Required]
        [IsStringLengthBelow(9, MinimumLength = 9, ErrorMessage = "Your SSN must be 9 numbers")]
        [IsNumeric]
        [Display(Name = "Social Security Number")]
		public string SSN { get; set; }

		[Required]
        [IsStringLengthBelow(50)]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

		public User User { get; set; }
	}
}