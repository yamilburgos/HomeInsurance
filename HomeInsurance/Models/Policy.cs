using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeInsurance.Models {

    public class Policy {

        public int Id { get; set; }

        [Display(Name = "Quote Id")]
        [ForeignKey("Quote")]
        public int QuoteId { get; set; }

        public Quote Quote { get; set; }

        [Display(Name = "Policy Key")]
        public string PolicyKey { get; set; }

        [Display(Name = "Policy Effective Date")]
        public string PolicyEffDate { get; set; }

        [Display(Name = "Policy End Date")]
        public string PolicyEndDate { get; set; }

        [Display(Name = "Policy Term")]
        public int PolicyTerm { get; set; }

        [Display(Name = "Policy Status")]
        public string PolicyStatus { get; set; }
    }
}