using FoodLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodLog.ViewModels
{
    public class FoodEatenViewModel
    {

        public DateTime DateEaten { get; set; }

        public List<FoodEatenModel> FoodEaten { get; set; }

    }
}