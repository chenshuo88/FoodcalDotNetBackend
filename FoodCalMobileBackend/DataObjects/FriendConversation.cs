using System;
using Microsoft.WindowsAzure.Mobile.Service;


namespace FoodCalMobileBackend.DataObjects
{
    public class FriendConversation : EntityData
    {
        //public string FromUserID { get; set; }

        public string ToUserID { get; set; }

        public DateTime TimeStamp { get; set; }

        public string MessageType { get; set; }

        public string Contents { get; set; }
    }
}