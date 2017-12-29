using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeInsurance.Models {

    [NotMapped]
    public class VerifyPolicy {
        public int Id { get; set; }

        [Display(Name = "Quote Id")]
        public int QuoteId { get; set; }

        [IsPolicyDateValid]
        [Display(Name = "Enter Policy Start Date")]
        public string PolicyStartDate { get; set; }

        public bool Acknowledge { get; set; }
    }
}