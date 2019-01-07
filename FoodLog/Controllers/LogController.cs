using FoodLog.Models;
using FoodLog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodLog.Controllers
{
    public class LogController : Controller
    {
        List<FoodEatenModel> foodEaten = new List<FoodEatenModel>()
        {
            new FoodEatenModel()
            {
                 DateEaten = DateTime.Today,
                  Food = new FoodModel(){ Name = "Black Beans"}
            },
            new FoodEatenModel(){ },
        };

        // GET: Log
        public ActionResult Index()
        {
            var foodEaten = new FoodEatenViewModel();
            foodEaten.DateEaten = DateTime.Today;
            foodEaten.FoodEaten.AddRange(new List<FoodEatenModel>());//Get from DBContext
            return View();
        }

        // GET: Log
        public ActionResult Index(DateTime DateEaten)
        {
            var foodEaten = new FoodEatenViewModel();
            foodEaten.DateEaten = DateEaten;
            foodEaten.FoodEaten.AddRange(new List<FoodEatenModel>());//Get from DBContext
            return View();
        }
    }
}