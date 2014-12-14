using Microsoft.WindowsAzure.Mobile.Service;


namespace FoodCalMobileBackend.DataObjects
{
    public class UserNotificationSetting : EntityData
    {
        //public string UserID { get; set; }

        public bool FriendInvites { get; set; }

        public bool GroupInvites { get; set; }

        public bool MealInvites { get; set; }

        public bool FriendShares { get; set; }

        public bool BirthdayNotifications { get; set; }

        public bool EventsNotifications { get; set; }

        public bool RecoForRestaurant { get; set; }

        public bool RecoForFriends { get; set; }

        public bool RecoForDishes { get; set; }

        public bool RecoForDeals { get; set; }
    }
}