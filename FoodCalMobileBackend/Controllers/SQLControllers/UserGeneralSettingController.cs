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
    public class UserGeneralSettingController : TableController<UserGeneralSetting>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<UserGeneralSetting>(context, Request, Services);
        }

        // GET tables/UserGeneralSetting
        public IQueryable<UserGeneralSetting> GetAllUserGeneralSetting()
        {
            return Query(); 
        }

        // GET tables/UserGeneralSetting/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<UserGeneralSetting> GetUserGeneralSetting(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/UserGeneralSetting/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<UserGeneralSetting> PatchUserGeneralSetting(string id, Delta<UserGeneralSetting> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/UserGeneralSetting
        public async Task<IHttpActionResult> PostUserGeneralSetting(UserGeneralSetting item)
        {
            UserGeneralSetting current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/UserGeneralSetting/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteUserGeneralSetting(string id)
        {
             return DeleteAsync(id);
        }

    }
}