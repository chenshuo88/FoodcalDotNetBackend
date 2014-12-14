using System;
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
    public class UserProfileController : TableController<UserProfile>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<UserProfile>(context, Request, Services);
        }

        // GET tables/UserProfile
        public IQueryable<UserProfile> GetAllUserProfile()
        {
            return Query(); 
        }

        // GET tables/UserProfile/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<UserProfile> GetUserProfile(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/UserProfile/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<UserProfile> PatchUserProfile(string id, Delta<UserProfile> patch)
        {
            Services.Log.Info("User " + patch.GetEntity().Name + " has been updated.");
            return UpdateAsync(id, patch);
        }

        // POST tables/UserProfile
        public async Task<IHttpActionResult> PostUserProfile(UserProfile item)
        {
            Services.Log.Info("A new user " + item.Name + " has registered to our system.");
            UserProfile current = await InsertAsync(item);

            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/UserProfile/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteUserProfile(string id)
        {
            Services.Log.Info("User " + id + " has been deleted from our system.");
            return DeleteAsync(id);
        }

    }
}