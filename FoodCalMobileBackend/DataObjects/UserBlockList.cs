using Microsoft.WindowsAzure.Mobile.Service;

namespace FoodCalMobileBackend.DataObjects
{
    public class UserBlockList : EntityData

    {
        //public string UserID { get; set; }

        public string BlockedUserID { get; set; }
    }
}