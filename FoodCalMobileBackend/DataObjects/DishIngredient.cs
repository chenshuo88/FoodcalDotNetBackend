using System;
using Microsoft.WindowsAzure.Mobile.Service;

namespace FoodCalMobileBackend.DataObjects
{
    public class DishIngredient : EntityData
    {

        //public string DishID { get; set; }

        public string RestaurantID { get; set; }

        public string Ingredients { get; set; }

        public float Amount { get; set; }
    }
}