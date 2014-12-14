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
    public class UserPrivacySettingController : TableController<UserPrivacySetting>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<UserPrivacySetting>(context, Request, Services);
        }

        // GET tables/UserPrivacySetting
        public IQueryable<UserPrivacySetting> GetAllUserPrivacySetting()
        {
            return Query(); 
        }

        // GET tables/UserPrivacySetting/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<UserPrivacySetting> GetUserPrivacySetting(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/UserPrivacySetting/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<UserPrivacySetting> PatchUserPrivacySetting(string id, Delta<UserPrivacySetting> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/UserPrivacySetting
        public async Task<IHttpActionResult> PostUserPrivacySetting(UserPrivacySetting item)
        {
            UserPrivacySetting current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/UserPrivacySetting/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteUserPrivacySetting(string id)
        {
             return DeleteAsync(id);
        }

    }
}