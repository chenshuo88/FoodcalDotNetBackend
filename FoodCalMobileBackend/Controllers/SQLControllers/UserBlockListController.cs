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
    public class UserBlockListController : TableController<UserBlockList>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<UserBlockList>(context, Request, Services);
        }

        // GET tables/UserBlockList
        public IQueryable<UserBlockList> GetAllUserBlockList()
        {
            return Query(); 
        }

        // GET tables/UserBlockList/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<UserBlockList> GetUserBlockList(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/UserBlockList/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<UserBlockList> PatchUserBlockList(string id, Delta<UserBlockList> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/UserBlockList
        public async Task<IHttpActionResult> PostUserBlockList(UserBlockList item)
        {
            UserBlockList current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/UserBlockList/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteUserBlockList(string id)
        {
             return DeleteAsync(id);
        }

    }
}