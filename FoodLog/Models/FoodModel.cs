
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodLog.Models
{
    public class FoodModel
    {
        [Key]
        public int FoodId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual FoodTypeModel FoodType { get; set; }

        [Required]
        [Display(Name = "Serving Size (c)")]
        public double ServingSize { get; set; }

        [Required]
        public int Calories { get; set; }

        [Required]
        [Display(Name = "Protein (g)")]
        public double GramsOfProtein { get; set; }

        [Required]
        [Display(Name = "Fat (g)")]
        public double GramsOfFat { get; set; }

        [Required]
        [Display(Name = "Carb (g)")]
        public double GramsOfCarb { get; set; }

        public FoodModel()
        {
            FoodType = new FoodTypeModel();
        }
    }
}