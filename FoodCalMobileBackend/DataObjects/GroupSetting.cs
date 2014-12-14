using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;


namespace FoodCalMobileBackend.DataObjects
{
    public class GroupSetting : EntityData
    {

        //public string GroupID { get; set; }

        public Int16 GroupCapacity { get; set; }

        public bool NamesOnScreen { get; set; }

        public bool AlwaysOnTop { get; set; }

        public bool Notification { get; set; }
    }
}