using FoodLog.DataContext;
using FoodLog.Models;
using FoodLog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodLog.Controllers
{
    public class FoodController : Controller
    {
        //List<FoodModel> foods = new List<FoodModel>() {new FoodModel()
        //{
        //    FoodId = 1,
        //    Name = "Black Beans",
        //    ServingSize = 1,
        //    Calories = 227,
        //    GramsOfProtein = 15.2,
        //    GramsOfFat = .9,
        //    GramsOfCarb = 40.8,
        //    FoodType = FoodTypeModel.GetFoodTypeList().First(t => t.Name == "Legumes")
        //} };



        // GET: Food
        public ActionResult Index()
        {
            List<FoodModel> foods = new List<FoodModel>();
            using (var db = new FoodLogContext())
            {
                foods.AddRange(db.Foods.ToList());
            }
            return View(foods);
        }

        // GET: Food/Create
        public ActionResult Create()
        {
            var foodVM = new FoodViewModel()
            {
                Food = new FoodModel(),
                SelectedFoodType = string.Empty,
                FoodTypesSelectList = GetFoodTypeSelectList()
            };

            return View(foodVM);
        }

        // POST: Food/Create
        [HttpPost]
        public ActionResult Create(FoodViewModel newFood)
        {
            try
            {
                // TODO: Add insert logic here
                var food = new FoodModel()
                {
                    Name = newFood.Food.Name,
                    Calories = newFood.Food.Calories,
                    GramsOfCarb = newFood.Food.GramsOfCarb,
                    GramsOfFat = newFood.Food.GramsOfFat,
                    GramsOfProtein = newFood.Food.GramsOfProtein
                };
                food.FoodType = food.FoodType.FoodTypes.First(t => t.Name == newFood.SelectedFoodType);

                using (var db = new FoodLogContext())
                {
                    db.Foods.Add(food);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Food/Edit/5
        public ActionResult Edit(int FoodId)
        {
            //return View(new FoodViewModel()
            //{
            //    Food = foods.First(food => food.FoodId == FoodId),
            //    SelectedFoodType = string.Empty,
            //    FoodTypesSelectList = GetFoodTypeSelectList()
            //});

            FoodModel food;
            using (var db = new FoodLogContext())
            {
                food = db.Foods.First(t => t.FoodId == FoodId);
            }

            return View(new FoodViewModel()
            {
                Food = food,
                SelectedFoodType = string.Empty,
                FoodTypesSelectList = GetFoodTypeSelectList()
            });
        }

        // POST: Food/Edit/5
        [HttpPost]
        public ActionResult Edit(int FoodId, FoodViewModel editedFood)
        {
            try
            {
                // TODO: Add update logic here
                //var food = foods.First(f => f.FoodId == FoodId);
                using (var db = new FoodLogContext())
                {
                    var food = db.Foods.First(f => f.FoodId == FoodId);
                    food.Name = editedFood.Food.Name;
                    food.Calories = editedFood.Food.Calories;
                    food.GramsOfCarb = editedFood.Food.GramsOfCarb;
                    food.GramsOfFat = editedFood.Food.GramsOfFat;
                    food.GramsOfProtein = editedFood.Food.GramsOfProtein;
                    food.FoodType = food.FoodType.FoodTypes.First(t => t.Name == editedFood.SelectedFoodType);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Food/Delete/5
        public ActionResult Delete(int FoodId)
        {
            using (var db = new FoodLogContext())
            {
                db.Foods.Remove(db.Foods.First(food => food.FoodId == FoodId));
                db.SaveChanges();
            }
            //foods.Remove(foods.First(food => food.FoodId == FoodId));
            return RedirectToAction("Index");
        }

        // POST: Food/Delete/5
        [HttpPost]
        public ActionResult Delete(int FoodId, FormCollection collection)
        {
            try
            {
                using (var db = new FoodLogContext())
                {
                    db.Foods.Remove(db.Foods.First(food => food.FoodId == FoodId));
                    db.SaveChanges();
                }

                // TODO: Add delete logic here
                //foods.Remove(foods.First(food => food.FoodId == FoodId));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        private IEnumerable<SelectListItem> GetFoodTypeSelectList()
        {
            var selectList = new List<SelectListItem>();
            using (var db = new FoodLogContext())
            {
                foreach (var foodType in db.FoodTypes.ToList())
                {
                    selectList.Add(new SelectListItem() { Value = foodType.Name, Text = foodType.Name });
                }
            }
            //foreach (var foodType in FoodTypeModel.GetFoodTypeList())
            //{
            //    selectList.Add(new SelectListItem() { Value = foodType.Name, Text = foodType.Name });
            //}
            return selectList;
        }
    }
}
