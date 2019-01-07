namespace FoodLog.Migrations
{
    using FoodLog.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FoodLog.DataContext.FoodLogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FoodLog.DataContext.FoodLogContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.FoodTypes.AddOrUpdate(new FoodTypeModel() { Name = "Legumes", FoodTypeId = 1 }, new FoodTypeModel() { Name = "Fruit", FoodTypeId = 2 });
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
