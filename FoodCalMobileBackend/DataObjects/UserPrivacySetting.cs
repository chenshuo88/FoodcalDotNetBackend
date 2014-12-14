using Microsoft.WindowsAzure.Mobile.Service;


namespace FoodCalMobileBackend.DataObjects
{
    public class UserPrivacySetting : EntityData
    {
        //public string UserID { get; set; }

        public bool FriendConfirmation { get; set; }

        public bool FindMeByPhone { get; set; }

        public bool FindMeById { get; set; }

        public bool LocationService { get; set; }

        public bool BlockedList { get; set; }

        public bool InvitesFromStranger { get; set; }

        public bool CalenderSharing { get; set; }
    }
}