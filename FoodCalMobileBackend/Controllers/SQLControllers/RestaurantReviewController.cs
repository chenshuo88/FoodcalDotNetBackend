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
    public class RestaurantReviewController : TableController<RestaurantReview>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<RestaurantReview>(context, Request, Services);
        }

        // GET tables/RestaurantReview
        public IQueryable<RestaurantReview> GetAllRestaurantReview()
        {
            return Query(); 
        }

        // GET tables/RestaurantReview/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<RestaurantReview> GetRestaurantReview(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/RestaurantReview/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<RestaurantReview> PatchRestaurantReview(string id, Delta<RestaurantReview> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/RestaurantReview
        public async Task<IHttpActionResult> PostRestaurantReview(RestaurantReview item)
        {
            RestaurantReview current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/RestaurantReview/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteRestaurantReview(string id)
        {
             return DeleteAsync(id);
        }

    }
}