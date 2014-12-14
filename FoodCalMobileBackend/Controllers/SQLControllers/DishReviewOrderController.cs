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
    public class DishReviewOrderController : TableController<DishReviewOrder>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<DishReviewOrder>(context, Request, Services);
        }

        // GET tables/DishReviewOrder
        public IQueryable<DishReviewOrder> GetAllDishReviewOrder()
        {
            return Query(); 
        }

        // GET tables/DishReviewOrder/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<DishReviewOrder> GetDishReviewOrder(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/DishReviewOrder/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<DishReviewOrder> PatchDishReviewOrder(string id, Delta<DishReviewOrder> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/DishReviewOrder
        public async Task<IHttpActionResult> PostDishReviewOrder(DishReviewOrder item)
        {
            DishReviewOrder current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/DishReviewOrder/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteDishReviewOrder(string id)
        {
             return DeleteAsync(id);
        }

    }
}