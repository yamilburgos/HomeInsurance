using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeInsurance.Models {

    [NotMapped]
    public class Login {

        [Required]
        [IsLengthBelow(20)]
        [IsAlphanumeric]
        public string Username { get; set; }

        [Required]
        [IsLengthBelow(20)]
        [IsAlphanumeric]
        public string Password { get; set; }

        [Required]
        [IsLengthBelow(20)]
        [IsAlphanumeric]
        [IsPasswordSame]
        [Display(Name = "Re-Enter Password")]
        public string ReEnterPassword { get; set; }
    }
}