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
    public class DishRecipeController : TableController<DishRecipe>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<DishRecipe>(context, Request, Services);
        }

        // GET tables/DishRecipe
        public IQueryable<DishRecipe> GetAllDishRecipe()
        {
            return Query(); 
        }

        // GET tables/DishRecipe/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<DishRecipe> GetDishRecipe(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/DishRecipe/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<DishRecipe> PatchDishRecipe(string id, Delta<DishRecipe> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/DishRecipe
        public async Task<IHttpActionResult> PostDishRecipe(DishRecipe item)
        {
            DishRecipe current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/DishRecipe/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteDishRecipe(string id)
        {
             return DeleteAsync(id);
        }

    }
}