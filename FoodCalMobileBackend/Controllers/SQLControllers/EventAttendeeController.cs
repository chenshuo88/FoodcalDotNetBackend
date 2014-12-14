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
    public class EventAttendeeController : TableController<EventAttendee>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<EventAttendee>(context, Request, Services);
        }

        // GET tables/EventAttendee
        public IQueryable<EventAttendee> GetAllEventAttendee()
        {
            return Query(); 
        }

        // GET tables/EventAttendee/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<EventAttendee> GetEventAttendee(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/EventAttendee/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<EventAttendee> PatchEventAttendee(string id, Delta<EventAttendee> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/EventAttendee
        public async Task<IHttpActionResult> PostEventAttendee(EventAttendee item)
        {
            EventAttendee current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/EventAttendee/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteEventAttendee(string id)
        {
             return DeleteAsync(id);
        }

    }
}