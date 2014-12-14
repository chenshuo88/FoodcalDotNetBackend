using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;


namespace FoodCalMobileBackend.DataObjects
{
    public class PostComment : EntityData
    {
        //public string PostID { get; set; }

        public string CommentID { get; set; }

        public DateTime Time { get; set; }

        public string ParentCommentID { get; set; }

        public string ContentType { get; set; }

        public string Content { get; set; }

        public Int32 Liked { get; set; }

        public Int32 Useful { get; set; }

        public Int32 Funny { get; set; }

        public Int32 Cool { get; set; }
    }
}