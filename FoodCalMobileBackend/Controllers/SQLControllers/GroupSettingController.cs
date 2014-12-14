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
    public class GroupSettingController : TableController<GroupSetting>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<GroupSetting>(context, Request, Services);
        }

        // GET tables/GroupSetting
        public IQueryable<GroupSetting> GetAllGroupSetting()
        {
            return Query(); 
        }

        // GET tables/GroupSetting/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<GroupSetting> GetGroupSetting(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/GroupSetting/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<GroupSetting> PatchGroupSetting(string id, Delta<GroupSetting> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/GroupSetting
        public async Task<IHttpActionResult> PostGroupSetting(GroupSetting item)
        {
            GroupSetting current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/GroupSetting/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteGroupSetting(string id)
        {
             return DeleteAsync(id);
        }

    }
}