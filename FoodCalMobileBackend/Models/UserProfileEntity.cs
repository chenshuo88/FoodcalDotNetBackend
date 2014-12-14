using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Storage.Table;

namespace FoodCalMobileBackend.Models
{
    public class UserProfileEntity : TableEntity
    {
        public UserProfileEntity(string Name, string UserID)
        {
            this.PartitionKey = Name;
            this.RowKey = UserID;
        }

        public UserProfileEntity() { }

        //public string UserID { get; set; }

        //public string Name { get; set; }

        public string Alias { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string HomePhone { get; set; }

        public string OfficePhone { get; set; }

        public DateTime RegisterTime { get; set; }

        public DateTime BirthDay { get; set; }

        public string Gender { get; set; }

        public string Industry { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Language { get; set; }

        public string SasUri { get; set; }

        public string ContainerUri { get; set; }

        public string PictureUri { get; set; }
    }
}