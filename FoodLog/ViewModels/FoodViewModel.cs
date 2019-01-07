using FoodLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodLog.ViewModels
{
    public class FoodViewModel
    {
        public FoodModel Food { get; set; }
        public string SelectedFoodType { get; set; }
        public IEnumerable<SelectListItem> FoodTypesSelectList { get; set; }
        


    }
}