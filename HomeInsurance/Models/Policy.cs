using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeInsurance.Models {

    public class Policy {

        public int Id { get; set; }

        [ForeignKey("Quote")]
        public int QuoteId { get; set; }

        public Quote Quote { get; set; }
        public string PolicyKey { get; set; }
        public string PolicyEffDate { get; set; }
        public string PolicyEndDate { get; set; }
        public int PolicyTerm { get; set; }
        public string PolicyStatus { get; set; }
    }
}