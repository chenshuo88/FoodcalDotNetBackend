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
    public class UserDeviceController : TableController<UserDevice>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<UserDevice>(context, Request, Services);
        }

        // GET tables/UserDevice
        public IQueryable<UserDevice> GetAllUserDevice()
        {
            return Query(); 
        }

        // GET tables/UserDevice/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<UserDevice> GetUserDevice(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/UserDevice/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<UserDevice> PatchUserDevice(string id, Delta<UserDevice> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/UserDevice
        public async Task<IHttpActionResult> PostUserDevice(UserDevice item)
        {
            UserDevice current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/UserDevice/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteUserDevice(string id)
        {
             return DeleteAsync(id);
        }

    }
}