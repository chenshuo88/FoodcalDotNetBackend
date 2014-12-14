using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;


namespace FoodCalMobileBackend.DataObjects
{
    public class Restaurant : EntityData
    {
        //public string RestaurantID { get; set; }

        public string Name { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string BusinessName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Website { get; set; }

        public string MenuWebsite { get; set; }

        public string FacebookLink { get; set; }

        public string Twitter { get; set; }

        public string OwnerName { get; set; }

        public string OwnerMobile { get; set; }

        public string SasUri { get; set; }

        public string ContainerUri { get; set; }

        public string PictureUri { get; set; }

        public string VideoSasUri { get; set; }

        public string VideoContainerUri { get; set; }

        public string VideoUri { get; set; }
    }
}