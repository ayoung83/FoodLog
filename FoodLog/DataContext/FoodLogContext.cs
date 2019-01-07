using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodLog.Models;

namespace FoodLog.DataContext
{
    public class FoodLogContext : DbContext
    {
        public DbSet<FoodEatenModel> FoodsEaten { get; set; }
        public DbSet<FoodModel> Foods { get; set; }
        public DbSet<FoodTypeModel> FoodTypes { get; set; }

        public FoodLogContext() : base("FoodLogLocal") { }

    }
}