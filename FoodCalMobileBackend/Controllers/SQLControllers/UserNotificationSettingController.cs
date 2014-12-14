using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using FoodCalMobileBackend.DataObjects;
using FoodCalMobileBackend.Models;

namespace FoodCalMobileBackend.Controllers
{
    [AuthorizeLevel(Microsoft.WindowsAzure.Mobile.Service.Security.AuthorizationLevel.Application)]
    public class UserNotificationSettingController : TableController<UserNotificationSetting>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<UserNotificationSetting>(context, Request, Services);
        }

        // GET tables/UserNotificationSetting
        public IQueryable<UserNotificationSetting> GetAllUserNotificationSetting()
        {
            return Query(); 
        }

        // GET tables/UserNotificationSetting/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<UserNotificationSetting> GetUserNotificationSetting(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/UserNotificationSetting/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<UserNotificationSetting> PatchUserNotificationSetting(string id, Delta<UserNotificationSetting> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/UserNotificationSetting
        public async Task<IHttpActionResult> PostUserNotificationSetting(UserNotificationSetting item)
        {
            UserNotificationSetting current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/UserNotificationSetting/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteUserNotificationSetting(string id)
        {
             return DeleteAsync(id);
        }

    }
}