using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;


namespace FoodCalMobileBackend.DataObjects
{
    public class GroupMember : EntityData
    {

        //public string GroupID { get; set; }

        public string MemberUserID { get; set; }

        public DateTime JoinTime { get; set; }

        public string RoleType { get; set; }

    }
}