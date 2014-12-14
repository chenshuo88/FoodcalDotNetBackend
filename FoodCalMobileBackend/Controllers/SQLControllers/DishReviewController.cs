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
    public class DishReviewController : TableController<DishReview>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<DishReview>(context, Request, Services);
        }

        // GET tables/DishReview
        public IQueryable<DishReview> GetAllDishReview()
        {
            return Query(); 
        }

        // GET tables/DishReview/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<DishReview> GetDishReview(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/DishReview/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<DishReview> PatchDishReview(string id, Delta<DishReview> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/DishReview
        public async Task<IHttpActionResult> PostDishReview(DishReview item)
        {
            DishReview current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/DishReview/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteDishReview(string id)
        {
             return DeleteAsync(id);
        }

    }
}