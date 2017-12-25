using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace HomeInsurance.Models {

    public class Quote {

        public int Id { get; set; }

        [ForeignKey("Property")]
        public int PropertyId { get; set; }

        public Property Property { get; set; }

        public double Premium { get; set; }
        public double DwellingCoverage { get; set; }
        public double DetachedStructure { get; set; }
        public double PersonalProperty { get; set; }
        public double AddnlLivgExpense { get; set; }
        public double MedicalExpense { get; set; }
        public double Deductible { get; set; }

        public Quote(Property property) {
            DwellingCoverage = 0.5 * property.MarketValue + CalculateHome(property);
            DetachedStructure = 0.1 * DwellingCoverage;
            PersonalProperty = 0.6 * DwellingCoverage;
            AddnlLivgExpense = 0.2 * DwellingCoverage;
            MedicalExpense = 5000;
            DetachedStructure = 0.01 * property.MarketValue;
        }

        public Quote() { }

        private double CalculateHome(Property property) {
            double constructionCost = 120 * property.SquareFootage;
            int year = DateTime.Now.Year, yearDifference = year - property.YearBuilt;

            return constructionCost * (1 - Reduction(yearDifference));
        }

        private double Reduction(int yearDifference) {
            if (yearDifference < 5) return 0.1;
            else if (yearDifference < 10) return 0.2;
            else if (yearDifference < 20) return 0.3;
            else return 0.5;
        }
    }
}