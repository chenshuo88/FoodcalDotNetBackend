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
    public class DishIngredientController : TableController<DishIngredient>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<DishIngredient>(context, Request, Services);
        }

        // GET tables/DishIngredient
        public IQueryable<DishIngredient> GetAllDishIngredient()
        {
            return Query(); 
        }

        // GET tables/DishIngredient/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<DishIngredient> GetDishIngredient(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/DishIngredient/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<DishIngredient> PatchDishIngredient(string id, Delta<DishIngredient> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/DishIngredient
        public async Task<IHttpActionResult> PostDishIngredient(DishIngredient item)
        {
            DishIngredient current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/DishIngredient/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteDishIngredient(string id)
        {
             return DeleteAsync(id);
        }

    }
}