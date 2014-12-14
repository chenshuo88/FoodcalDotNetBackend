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
    public class EventCommentController : TableController<EventComment>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<EventComment>(context, Request, Services);
        }

        // GET tables/EventComment
        public IQueryable<EventComment> GetAllEventComment()
        {
            return Query(); 
        }

        // GET tables/EventComment/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<EventComment> GetEventComment(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/EventComment/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<EventComment> PatchEventComment(string id, Delta<EventComment> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/EventComment
        public async Task<IHttpActionResult> PostEventComment(EventComment item)
        {
            EventComment current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/EventComment/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteEventComment(string id)
        {
             return DeleteAsync(id);
        }

    }
}