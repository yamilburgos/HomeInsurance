using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HomeInsurance.Models
{
    [NotMapped]
    public class VerifyPolicy
    {
        public int Id { get; set; }
        public int QuoteId { get; set; }
        public string PolicyStartDate { get; set; }
        public bool Acknowledge { get; set; }
    }
}