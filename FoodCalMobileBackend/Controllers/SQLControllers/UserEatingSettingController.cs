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
    public class UserEatingSettingController : TableController<UserEatingSetting>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<UserEatingSetting>(context, Request, Services);
        }

        // GET tables/UserEatingSetting
        public IQueryable<UserEatingSetting> GetAllUserEatingSetting()
        {
            return Query(); 
        }

        // GET tables/UserEatingSetting/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<UserEatingSetting> GetUserEatingSetting(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/UserEatingSetting/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<UserEatingSetting> PatchUserEatingSetting(string id, Delta<UserEatingSetting> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/UserEatingSetting
        public async Task<IHttpActionResult> PostUserEatingSetting(UserEatingSetting item)
        {
            UserEatingSetting current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/UserEatingSetting/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteUserEatingSetting(string id)
        {
             return DeleteAsync(id);
        }

    }
}