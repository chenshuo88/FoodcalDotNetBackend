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
    public class GroupController : TableController<Group>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Group>(context, Request, Services);
        }

        // GET tables/Group
        public IQueryable<Group> GetAllGroup()
        {
            return Query(); 
        }

        // GET tables/Group/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Group> GetGroup(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Group/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Group> PatchGroup(string id, Delta<Group> patch)
        {
            Services.Log.Info("Group " + patch.GetEntity().Name + " has been updated.");
            return UpdateAsync(id, patch);
        }

        // POST tables/Group
        public async Task<IHttpActionResult> PostGroup(Group item)
        {
            Services.Log.Info("A new Group " + item.Name + " has registered to our system.");
            Group current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Group/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteGroup(string id)
        {
            Services.Log.Info("Group " + id + " has been deleted from our system.");
            return DeleteAsync(id);
        }

    }
}