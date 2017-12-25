using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeInsurance.Models {

    [NotMapped]
    public class Login {

        [Required]
        [StringLength(20)]
        [IsAlphanumeric]
        [Display(Name = "Username: ")]
        public string Username { get; set; }

        [Required]
        [StringLength(20)]
        [IsAlphanumeric]
        [Display(Name = "Password: ")]
        public string Password { get; set; }

        [Required]
        [StringLength(20)]
        [IsAlphanumeric]
        [IsPasswordSame]
        [Display(Name = "Re-Enter Password: ")]
        public string ReEnterPassword { get; set; }
    }
}