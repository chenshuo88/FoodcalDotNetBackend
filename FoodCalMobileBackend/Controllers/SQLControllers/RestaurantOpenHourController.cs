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
    public class RestaurantOpenHourController : TableController<RestaurantOpenHour>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<RestaurantOpenHour>(context, Request, Services);
        }

        // GET tables/RestaurantOpenHour
        public IQueryable<RestaurantOpenHour> GetAllRestaurantOpenHour()
        {
            return Query(); 
        }

        // GET tables/RestaurantOpenHour/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<RestaurantOpenHour> GetRestaurantOpenHour(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/RestaurantOpenHour/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<RestaurantOpenHour> PatchRestaurantOpenHour(string id, Delta<RestaurantOpenHour> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/RestaurantOpenHour
        public async Task<IHttpActionResult> PostRestaurantOpenHour(RestaurantOpenHour item)
        {
            RestaurantOpenHour current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/RestaurantOpenHour/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteRestaurantOpenHour(string id)
        {
             return DeleteAsync(id);
        }

    }
}