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
    public class PostCommentController : TableController<PostComment>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<PostComment>(context, Request, Services);
        }

        // GET tables/PostComment
        public IQueryable<PostComment> GetAllPostComment()
        {
            return Query(); 
        }

        // GET tables/PostComment/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<PostComment> GetPostComment(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/PostComment/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<PostComment> PatchPostComment(string id, Delta<PostComment> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/PostComment
        public async Task<IHttpActionResult> PostPostComment(PostComment item)
        {
            PostComment current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/PostComment/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeletePostComment(string id)
        {
             return DeleteAsync(id);
        }

    }
}