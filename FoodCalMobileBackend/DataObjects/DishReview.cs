using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;


namespace FoodCalMobileBackend.DataObjects
{
    public class DishReview : EntityData
    {

        //public string DishID { get; set; }

        public string RestaurantID { get; set; }

        public string PostID { get; set; }

        public DateTime Time { get; set; }

        public string ReviewUserID { get; set; }

        public string ReviewTitle { get; set; }

        public Int16 ReviewRating { get; set; }

        public string SasUri { get; set; }

        public string ContainerUri { get; set; }

        public string PictureUri { get; set; }

        public string VideoSasUri { get; set; }

        public string VideoContainerUri { get; set; }

        public string VideoUri { get; set; }

        public string ContentType { get; set; }

        public string Content { get; set; }

        public Int16 Liked { get; set; }

        public Int16 Useful { get; set; }

        public Int16 Funny { get; set; }

        public Int16 Cool { get; set; }
    }
}