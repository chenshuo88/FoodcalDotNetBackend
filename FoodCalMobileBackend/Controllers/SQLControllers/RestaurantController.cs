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
    public class RestaurantController : TableController<Restaurant>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Restaurant>(context, Request, Services);
        }

        // GET tables/Restaurant
        public IQueryable<Restaurant> GetAllRestaurant()
        {
            return Query(); 
        }

        // GET tables/Restaurant/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Restaurant> GetRestaurant(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Restaurant/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Restaurant> PatchRestaurant(string id, Delta<Restaurant> patch)
        {
            Services.Log.Info("Restaurant " + patch.GetEntity().Name + " has been updated.");
            return UpdateAsync(id, patch);
        }

        // POST tables/Restaurant
        public async Task<IHttpActionResult> PostRestaurant(Restaurant item)
        {
            Services.Log.Info("A new Restaurant " + item.Name + " has registered to our system.");
            Restaurant current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Restaurant/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteRestaurant(string id)
        {
            Services.Log.Info("Restaurant " + id + " has been deleted from our system.");
            return DeleteAsync(id);
        }

    }
}