namespace HomeInsurance.Migrations {
    using HomeInsurance.Models;
    using System.Data.Entity.Migrations;
    
    internal sealed class Configuration : DbMigrationsConfiguration<HomeInsurance.Models.QuotesEntity> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HomeInsurance.Models.QuotesEntity context) {
            User user = new User { Username = "Joe Schmoe", Password = "Secret", IsAdmin = true };
            context.Users.AddOrUpdate(user);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}