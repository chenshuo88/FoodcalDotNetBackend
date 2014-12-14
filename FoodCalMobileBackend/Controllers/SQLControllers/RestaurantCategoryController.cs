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
    public class RestaurantCategoryController : TableController<RestaurantCategory>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<RestaurantCategory>(context, Request, Services);
        }

        // GET tables/RestaurantCategory
        public IQueryable<RestaurantCategory> GetAllRestaurantCategory()
        {
            return Query(); 
        }

        // GET tables/RestaurantCategory/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<RestaurantCategory> GetRestaurantCategory(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/RestaurantCategory/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<RestaurantCategory> PatchRestaurantCategory(string id, Delta<RestaurantCategory> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/RestaurantCategory
        public async Task<IHttpActionResult> PostRestaurantCategory(RestaurantCategory item)
        {
            RestaurantCategory current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/RestaurantCategory/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteRestaurantCategory(string id)
        {
             return DeleteAsync(id);
        }

    }
}