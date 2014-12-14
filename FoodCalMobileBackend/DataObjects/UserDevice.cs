using System;
using Microsoft.WindowsAzure.Mobile.Service;

namespace FoodCalMobileBackend.DataObjects
{
    public class UserDevice : EntityData
    {
        //public string DevicdID { get; set; }

        public string UserID { get; set; }

        public string MobileBrand { get; set; }

        public string MobileModel { get; set; }

        public string OS { get; set; }
    }
}