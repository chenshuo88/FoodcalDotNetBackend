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
    public class FriendConversationController : TableController<FriendConversation>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<FriendConversation>(context, Request, Services);
        }

        // GET tables/FriendConversation
        public IQueryable<FriendConversation> GetAllFriendConversation()
        {
            return Query(); 
        }

        // GET tables/FriendConversation/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<FriendConversation> GetFriendConversation(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/FriendConversation/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<FriendConversation> PatchFriendConversation(string id, Delta<FriendConversation> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/FriendConversation
        public async Task<IHttpActionResult> PostFriendConversation(FriendConversation item)
        {
            FriendConversation current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/FriendConversation/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteFriendConversation(string id)
        {
             return DeleteAsync(id);
        }

    }
}