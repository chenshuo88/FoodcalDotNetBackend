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
    public class RestaurantDetailController : TableController<RestaurantDetail>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<RestaurantDetail>(context, Request, Services);
        }

        // GET tables/RestaurantDetail
        public IQueryable<RestaurantDetail> GetAllRestaurantDetail()
        {
            return Query(); 
        }

        // GET tables/RestaurantDetail/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<RestaurantDetail> GetRestaurantDetail(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/RestaurantDetail/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<RestaurantDetail> PatchRestaurantDetail(string id, Delta<RestaurantDetail> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/RestaurantDetail
        public async Task<IHttpActionResult> PostRestaurantDetail(RestaurantDetail item)
        {
            RestaurantDetail current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/RestaurantDetail/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteRestaurantDetail(string id)
        {
             return DeleteAsync(id);
        }

    }
}