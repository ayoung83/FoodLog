using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodLog.Models
{
    public class FoodEatenModel
    {
        [Key]
        public int FoodEatenId { get; set; }

        [Required]
        [Display(Name = "Date Eaten")]
        public DateTime DateEaten { get; set; }

        [Required]
        public float Servings { get; set; }

        public virtual FoodModel Food { get; set; }
    }
}