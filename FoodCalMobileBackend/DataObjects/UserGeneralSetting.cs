using Microsoft.WindowsAzure.Mobile.Service;

namespace FoodCalMobileBackend.DataObjects
{
    public class UserGeneralSetting : EntityData

    {
        //public string UserID { get; set; }

        public bool ConfirmToExit { get; set; }

        public bool PostToFacebook { get; set; }

        public bool PostToInstagram { get; set; }
    }
}