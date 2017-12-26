using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeInsurance.Models {

    public class Property {

        public int Id { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }

        public Location Location { get; set; }

        [Range(10000, 100000000)]
        public int MarketValue { get; set; }

        [Range(1860, 2030)]
        public int YearBuilt { get; set; }

        [Range(50, 1000000)]
        public int SquareFootage { get; set; }

        [Required]
        public string DwellingStyle { get; set; }

        [Required]
        public string RoofMaterial { get; set; }

        [Required]
        public string GarageType { get; set; }

        [Required]
        public string NumFullBaths { get; set; }

        [Required]
        public string NumHalfBaths { get; set; }

        [Required]
        public bool HasSwimmingPool { get; set; }

        public readonly List<string> DwellingStyles = new List<string> {
            "1 Story",
            "1.5 Story",
            "2 Story",
            "2.5 Story",
            "3 Story"
        };

        public readonly List<string> RoofMaterials = new List<string> {
            "Concrete",
            "Clay",
            "Rubber",
            "Steel",
            "Tin",
            "Wood"
        };

        public readonly List<string> GarageTypes = new List<string> {
            "Attached",
            "Detached",
            "Basement",
            "Built -in",
            "None"
        };

        public readonly List<string> Baths = new List<string> {
            "1",
            "2",
            "3",
            "More"
        };
    }
}