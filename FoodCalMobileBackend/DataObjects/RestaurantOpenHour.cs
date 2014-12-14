using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;


namespace FoodCalMobileBackend.DataObjects
{
    public class RestaurantOpenHour : EntityData
    {
        //public string RestaurantID { get; set; }

        public DateTime SpecialDate { get; set; }

        public string WeekDay { get; set; }

        public DateTime OpenTime { get; set; }

        public DateTime CloseTime { get; set; }
    }
}