using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeInsurance.Models {

    public class Homeowner {


        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required] [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required] [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required] [Display(Name = "Date of Birth")]
        public string DOB { get; set;}
        [Required] [Display(Name = "Are you retired?")]
        public bool IsRetired { get; set; }
        [Required] [Display(Name = "Social Security Number")]
        public string SSN { get; set; }
        [Required] [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        public User User { get; set; }

    }
}