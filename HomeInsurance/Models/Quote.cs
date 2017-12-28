using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeInsurance.Models {

    public class Quote {

        public int Id { get; set; }

        [ForeignKey("Property")]
        public int PropertyId { get; set; }

        public Property Property { get; set; }

        public double MonthlyPremium { get; set; }
        public double DwellingCoverage { get; set; }
        public double DetachedStructure { get; set; }
        public double PersonalProperty { get; set; }
        public double AddnlLivgExpense { get; set; }
        public double MedicalExpense { get; set; }
        public double Deductible { get; set; }

        public Quote() {}

        public Quote(Property property) {
            DwellingCoverage = (0.50 * property.MarketValue) + CalculateHome(property);
            DetachedStructure = 0.10 * DwellingCoverage;
            PersonalProperty = 0.60 * DwellingCoverage;
            AddnlLivgExpense = 0.20 * DwellingCoverage;
            MedicalExpense = 5000;
            Deductible = 0.01 * property.MarketValue;
            MonthlyPremium = CalculateRate(property);
        }

        private double CalculateRate(Property property) {
            int year = DateTime.Now.Year, yearDifference = year - property.YearBuilt;
            double rate = 5 * yearDifference * (DwellingCoverage / 1000);
            double residenceFee = AddToPremium(property, rate);

            return Math.Round((rate + residenceFee) / 12, 2);
        }

        private double AddToPremium(Property property, double rate) {
            switch(property.Location.ResidenceType) {
                case "Condo":
                case "Duplex":
                case "Apartment":
                    return rate * .06;
                case "Townhouse":
                case "Rowhouse":
                    return rate * .07;
                default:
                    return rate * .05;
            }
        }

        private double CalculateHome(Property property) {
            double constructionCost = 120 * property.SquareFootage;
            int year = DateTime.Now.Year, yearDifference = year - property.YearBuilt;

            return constructionCost * (1 - Reduction(yearDifference));
        }

        private double Reduction(int yearDifference) {
            if (yearDifference < 5) return 0.10;
            else if (yearDifference < 10) return 0.20;
            else if (yearDifference < 20) return 0.30;
            else return 0.50;
        }
    }
}