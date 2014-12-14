using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;


namespace FoodCalMobileBackend.DataObjects
{
    public class Group : EntityData
    {

        //public string GroupID { get; set; }

        public string CreatorUserID { get; set; }

        public DateTime TimeCreated { get; set; }

        public string SasUri { get; set; }

        public string ContainerUri { get; set; }

        public string PictureUri { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}