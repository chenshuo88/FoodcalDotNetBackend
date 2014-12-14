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
    public class DishNutrientController : TableController<DishNutrient>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<DishNutrient>(context, Request, Services);
        }

        // GET tables/DishNutrient
        public IQueryable<DishNutrient> GetAllDishNutrient()
        {
            return Query(); 
        }

        // GET tables/DishNutrient/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<DishNutrient> GetDishNutrient(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/DishNutrient/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<DishNutrient> PatchDishNutrient(string id, Delta<DishNutrient> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/DishNutrient
        public async Task<IHttpActionResult> PostDishNutrient(DishNutrient item)
        {
            DishNutrient current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/DishNutrient/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteDishNutrient(string id)
        {
             return DeleteAsync(id);
        }

    }
}