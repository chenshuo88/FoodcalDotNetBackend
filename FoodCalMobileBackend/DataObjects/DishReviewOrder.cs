using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;


namespace FoodCalMobileBackend.DataObjects
{
    public class DishReviewOrder : EntityData
    {

        //public string DishID { get; set; }

        public string RestaurantID { get; set; }

        public string address { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public Int32 AverageRating { get; set; }

        public Int32 TotalRating { get; set; }

        public Int32 Liked { get; set; }
    }
}