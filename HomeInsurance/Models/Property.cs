using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeInsurance.Models {

    public class Property {
        public int Id { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }

        public Location Location { get; set; }
        
        [Range(10000,100000000)]
        public int MarketValue { get; set; }

        [Range(1860,2030)]
        public int YearBuilt { get; set; }

        [Range(50, 1000000)]
        public int SquareFootage { get; set; }
        public int DwellingStyle { get; set; }
        public string RoofMaterial { get; set; }
        public string GarageType { get; set; }
        public int NumFullBaths { get; set; }
        public int NumHalfBaths { get; set; }
        public bool HasSwimmingPool { get; set; }
    }
}