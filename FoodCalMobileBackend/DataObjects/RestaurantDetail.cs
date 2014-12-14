using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;


namespace FoodCalMobileBackend.DataObjects
{
    public class RestaurantDetail : EntityData
    {
        //public string RestaurantID { get; set; }

        public Int16 Expensiveness { get; set; }

        public Int16 Seats { get; set; }

        public bool TakeReservations { get; set; }

        public bool Delivery { get; set; }

        public bool TakeOut { get; set; }

        public bool AcceptCreditCards { get; set; }

        public string ParkingType { get; set; }

        public bool BikeParking { get; set; }

        public bool WheelChairAccess { get; set; }

        public bool GoodForKids { get; set; }

        public bool GoodForGroups { get; set; }

        public string Attire { get; set; }

        public string Ambience { get; set; }

        public string NoiceLevel { get; set; }

        public bool Alcohol { get; set; }

        public bool outdoorSpace { get; set; }

        public bool Barservice { get; set; }

        public bool Bathrooms { get; set; }

        public bool LunchSpecial { get; set; }

        public bool WIFI { get; set; }

        public bool HasTV { get; set; }

        public bool DogsAllowed { get; set; }

        public bool WaiterService { get; set; }

        public bool Caters { get; set; }

        public bool ValetParking { get; set; }
    }
}