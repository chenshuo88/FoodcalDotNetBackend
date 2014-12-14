using Microsoft.WindowsAzure.Mobile.Service;


namespace FoodCalMobileBackend.DataObjects
{
    public class Friend : EntityData
    {
        //public string UserID { get; set; }

        public string FriendUserID { get; set; }

        public string FriendType { get; set; }

    }
}