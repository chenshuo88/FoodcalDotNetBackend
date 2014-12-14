using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Storage.Table.DataServices;


namespace FoodCalMobileBackend.DataObjects
{
    public class Dish : EntityData
    {

        //public string DishID { get; set; }

        public string RestaurantID { get; set; }

        public string Name { get; set; }

        public string LifeCycleStatus { get; set; }

        public string SasUri { get; set; }

        public string ContainerUri { get; set; }

        public string PictureUri { get; set; }

        public string VideoSasUri { get; set; }

        public string VideoContainerUri { get; set; }

        public string VideoUri { get; set; }

        public string DishType { get; set; }

        public DateTime TimeToMarket { get; set; }

        public Int16 Sweetness { get; set; }

        public Int16 Saltiness { get; set; }

        public Int16 Spiciness { get; set; }

    }
}