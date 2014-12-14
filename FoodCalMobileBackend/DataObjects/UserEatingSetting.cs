using System;
using Microsoft.WindowsAzure.Mobile.Service;


namespace FoodCalMobileBackend.DataObjects
{
    public class UserEatingSetting : EntityData
    {
        //public string UserID { get; set; }

        public bool IsVegetarian { get; set; }

        public bool IsMeetlover { get; set; }

        public bool IsIslam { get; set; }

        public bool NoPork { get; set; }

        public bool NoMutton { get; set; }

        public bool NoBeef { get; set; }

        public bool NoSeafood { get; set; }

        public bool LowSodium { get; set; }

        public bool Diabetic { get; set; }

        public string FavoriteStyle { get; set; }

        public bool IsFoodAllergy { get; set; }

        public string FoodAllergies { get; set; }

        public Int16 EatingRadius { get; set; }
    }
}