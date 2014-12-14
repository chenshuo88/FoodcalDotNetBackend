using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;


namespace FoodCalMobileBackend.DataObjects
{
    public class RestaurantCategory : EntityData
    {
        //public string RestaurantID { get; set; }

        public string Category { get; set; }
    }
}