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
    public class DishController : TableController<Dish>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Dish>(context, Request, Services);
        }

        // GET tables/Dish
        public IQueryable<Dish> GetAllDish()
        {
            return Query(); 
        }

        // GET tables/Dish/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Dish> GetDish(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Dish/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Dish> PatchDish(string id, Delta<Dish> patch)
        {
            Services.Log.Info("Dish " + patch.GetEntity().Name + " has been updated.");
            return UpdateAsync(id, patch);
        }

        // POST tables/Dish
        public async Task<IHttpActionResult> PostDish(Dish item)
        {
            Services.Log.Info("A new dish " + item.Name + " has registered to our system.");
            Dish current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Dish/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteDish(string id)
        {
            Services.Log.Info("Dish " + id + " has been deleted from our system.");
            return DeleteAsync(id);
        }

    }
}