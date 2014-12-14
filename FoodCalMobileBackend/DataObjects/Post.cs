using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;


namespace FoodCalMobileBackend.DataObjects
{
    public class Post : EntityData
    {

        //public string PostID { get; set; }

        public string UserID { get; set; }

        public DateTime Time { get; set; }

        public string Title { get; set; }

        public string SasUri { get; set; }

        public string ContainerUri { get; set; }

        public string PictureUri { get; set; }

        public string VideoSasUri { get; set; }

        public string VideoContainerUri { get; set; }

        public string VideoUri { get; set; }

        public string ContentType { get; set; }

        public string Content { get; set; }

        public Int32 Liked { get; set; }

        public Int32 Useful { get; set; }

        public Int32 Funny { get; set; }

        public Int32 Cool { get; set; }

    }
}