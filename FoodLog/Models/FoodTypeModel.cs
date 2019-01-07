using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodLog.Models
{
    public class FoodTypeModel
    {
        [Key]
        public int FoodTypeId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual IEnumerable<FoodTypeModel> FoodTypes { get { return GetFoodTypeList(); } }

        public static List<FoodTypeModel> GetFoodTypeList()
        {//Get this from DB
            var foodTypes = new List<FoodTypeModel>();
            foodTypes.Add(new FoodTypeModel() { Name = "Legumes", FoodTypeId = 1 });
            foodTypes.Add(new FoodTypeModel() { Name = "Fruit", FoodTypeId = 2 });
            return foodTypes;
        }

    }
}