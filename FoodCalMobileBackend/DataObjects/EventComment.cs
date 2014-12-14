using System;
using Microsoft.WindowsAzure.Mobile.Service;


namespace FoodCalMobileBackend.DataObjects
{
    public class EventComment : EntityData
    {

        //public string EventID { get; set; }

        public DateTime Time { get; set; }

        public string CommentId { get; set; }

        public string ParentCommentId { get; set; }

        public Int16 ReviewRating { get; set; }

        public string SasUri { get; set; }

        public string ContainerUri { get; set; }

        public string PictureUri { get; set; }

        public string VideoSasUri { get; set; }

        public string VideoContainerUri { get; set; }

        public string VideoUri { get; set; }

        public string Content { get; set; }

        public Int16 Liked { get; set; }

        public Int16 Useful { get; set; }

        public Int16 Funny { get; set; }

        public Int16 Cool { get; set; }
    }
}