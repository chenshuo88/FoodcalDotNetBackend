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
    public class RestaurantReviewOrderController : TableController<RestaurantReviewOrder>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<RestaurantReviewOrder>(context, Request, Services);
        }

        // GET tables/RestaurantReviewOrder
        public IQueryable<RestaurantReviewOrder> GetAllRestaurantReviewOrder()
        {
            return Query(); 
        }

        // GET tables/RestaurantReviewOrder/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<RestaurantReviewOrder> GetRestaurantReviewOrder(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/RestaurantReviewOrder/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<RestaurantReviewOrder> PatchRestaurantReviewOrder(string id, Delta<RestaurantReviewOrder> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/RestaurantReviewOrder
        public async Task<IHttpActionResult> PostRestaurantReviewOrder(RestaurantReviewOrder item)
        {
            RestaurantReviewOrder current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/RestaurantReviewOrder/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteRestaurantReviewOrder(string id)
        {
             return DeleteAsync(id);
        }

    }
}