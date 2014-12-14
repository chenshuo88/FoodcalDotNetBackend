using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Tables;
using FoodCalMobileBackend.DataObjects;

namespace FoodCalMobileBackend.Models
{

    public class MobileServiceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to alter your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
        //
        // To enable Entity Framework migrations in the cloud, please ensure that the 
        // service name, set by the 'MS_MobileServiceName' AppSettings in the local 
        // Web.config, is the same as the service name when hosted in Azure.

        private const string connectionStringName = "Name=MS_TableConnectionString";

        public MobileServiceContext()
            : base(connectionStringName)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            string schema = ServiceSettingsDictionary.GetSchemaName();
            if (!string.IsNullOrEmpty(schema))
            {
                modelBuilder.HasDefaultSchema(schema);
            }

            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
        }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.Dish> Dishes { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.DishNutrient> DishNutrients { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.DishRecipe> DishRecipes { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.DishReview> DishReviews { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.DishReviewOrder> DishReviewOrders { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.DishIngredient> DishIngredients { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.Event> Events { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.EventAttendee> EventAttendees { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.EventComment> EventComments { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.Friend> Friends { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.FriendConversation> FriendConversations { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.Group> Groups { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.GroupMember> GroupMembers { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.GroupSetting> GroupSettings { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.Post> Posts { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.PostComment> PostComments { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.Restaurant> Restaurants { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.RestaurantCategory> RestaurantCategories { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.RestaurantDetail> RestaurantDetails { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.RestaurantOpenHour> RestaurantOpenHours { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.RestaurantReview> RestaurantReviews { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.RestaurantReviewOrder> RestaurantReviewOrders { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.UserBlockList> UserBlockLists { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.UserEatingSetting> UserEatingSettings { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.UserGeneralSetting> UserGeneralSettings { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.UserLocation> UserLocations { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.UserNotificationSetting> UserNotificationSettings { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.UserPrivacySetting> UserPrivacySettings { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.UserProfile> UserProfiles { get; set; }

        public System.Data.Entity.DbSet<FoodCalMobileBackend.DataObjects.UserDevice> UserDevices { get; set; }
    }

}
