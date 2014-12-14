using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;


namespace FoodCalMobileBackend.DataObjects
{
    public class DishNutrient : EntityData
    {

        //public string DishID { get; set; }

        public string RestaurantID { get; set; }

        public float TotalCalories { get; set; }

        public float CaloriesFromFat { get; set; }

        public float TotalFat { get; set; }

        public float SaturatedFat { get; set; }

        public float TransFat { get; set; }

        public float Cholesterol { get; set; }

        public float TotalCarbohydrate { get; set; }

        public float Fiber { get; set; }

        public float DietaryFiber { get; set; }

        public float Sugars { get; set; }

        public float Calcium { get; set; }

        public float Iron { get; set; }

        public float Zinc { get; set; }

        public float Iodine { get; set; }

        public float Copper { get; set; }

        public float Sodium { get; set; }

        public float Potassium { get; set; }

        public float Magnesium { get; set; }

        public float Folicacid { get; set; }

        public float Protein { get; set; }

        public float VitaminA { get; set; }

        public float VitaminB6 { get; set; }

        public float VitaminB12 { get; set; }

        public float VitaminC { get; set; }

        public float VitaminD { get; set; }

        public float VitaminE { get; set; }
    }
}