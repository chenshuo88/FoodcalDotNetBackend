using System;
using Microsoft.WindowsAzure.Mobile.Service;


namespace FoodCalMobileBackend.DataObjects
{
    public class UserLocation : EntityData
    {
        //public string UserID { get; set; }

        public DateTime UpdateTime { get; set; }

        public string Location { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

    }
}