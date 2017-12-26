using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeInsurance.Models {

    public class Location {

        public int Id { get; set; }

        [ForeignKey("Homeowner")]
        public int HomeownerId { get; set; }

        public Homeowner Homeowner { get; set; }

        [Required]
        [Display(Name = "Residence Type")]
        public string ResidenceType { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Zip { get; set; }

        [Required]
        [Display(Name = "Residence Use")]
        public string ResidenceUse { get; set; }

        public readonly List<string> ResidenceTypes = new List<string> {
            "Single-Family Home",
            "Condo",
            "Townhouse",
            "Rowhouse",
            "Duplex",
            "Apartment"
        };

        public readonly List<string> ResidenceUses = new List<string> {
            "Primary",
            "Secondary",
            "Rental Property"
        };

        public string AddressLines {
            get { return String.Format("{0} {1}", AddressLine1, AddressLine2); }
		}
	}
}