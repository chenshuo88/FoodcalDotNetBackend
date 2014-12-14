using System;
using Microsoft.WindowsAzure.Mobile.Service;


namespace FoodCalMobileBackend.DataObjects
{
    public class Event : EntityData
    {

        //public string EventID { get; set; }

        public string OrganizerUserID { get; set; }

        public string address1 { get; set; }

        public string address2 { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public DateTime Time { get; set; }

        public string Name { get; set; }

        public string comments { get; set; }

        public string SasUri { get; set; }

        public string ContainerUri { get; set; }

        public string PictureUri { get; set; }

        public string VideoSasUri { get; set; }

        public string VideoContainerUri { get; set; }

        public string VideoUri { get; set; }

    }
}