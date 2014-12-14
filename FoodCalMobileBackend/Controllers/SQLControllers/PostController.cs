using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using FoodCalMobileBackend.DataObjects;
using FoodCalMobileBackend.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace FoodCalMobileBackend.Controllers
{
    [AuthorizeLevel(Microsoft.WindowsAzure.Mobile.Service.Security.AuthorizationLevel.Application)]
    public class PostController : TableController<Post>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Post>(context, Request, Services);
        }

        // GET tables/Post
        public IQueryable<Post> GetAllPost()
        {
            return Query(); 
        }

        // GET tables/Post/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Post> GetPost(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Post/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Post> PatchPost(string id, Delta<Post> patch)
        {
            Services.Log.Info("Post '" + patch.GetEntity().Title + "' has been updated.");
            return UpdateAsync(id, patch);
        }

        // POST tables/Post
        public async Task<IHttpActionResult> PostPost(Post item)
        {
            Services.Log.Info("A new Post '" + item.Title + "' has registered to our system.");
            Post current = await InsertAsync(item);
            // Insert the Post profile picture into the Azure Blob storage
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(this.Services.Settings["STORAGE_CONNECTION_STRING"]);

                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
                CloudTable table = tableClient.GetTableReference("Post");
                table.CreateIfNotExists();


                // Insert the picture blob
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("userpostpicture");
                container.CreateIfNotExists(BlobContainerPublicAccessType.Blob);

                // set policy
                SharedAccessBlobPolicy policy = new SharedAccessBlobPolicy();
                policy.SharedAccessStartTime = DateTime.UtcNow.AddMinutes(-5);
                policy.SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(5);
                policy.Permissions = SharedAccessBlobPermissions.Write;

                // generate the shared access signature(SAS) token for the container
                string sasContainerToken = container.GetSharedAccessSignature(policy);
                item.SasUri = sasContainerToken;
                item.ContainerUri = container.Uri.ToString();
                item.PictureUri = string.Format("{0}/{1}/{2}", container.Uri, "files", item.Id + ".jpg");

            }
            catch (Exception e)
            {
                Services.Log.Error(e.ToString());
            }

            // Send push notification to all the publisher's friends
            await SendPushNotification("post", item.UserID);

            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Post/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeletePost(string id)
        {
            Services.Log.Info("Post " + id + " has been deleted from our system.");
            return DeleteAsync(id);
        }

        // We are using the userID as tag here, add a friend equals register to the
        // friend notification
        public async Task SendPushNotification(string messageToSend, string userID)
        {
            try
            {
                String wnsToast = System.String.Format("<toast><visual><binding template=\"ToastText01\">"
                    + "<tet id=\"1\">" + messageToSend + "</text></binding></visual></toast>");
                WindowsPushMessage message = new WindowsPushMessage();
                message.XmlPayload = wnsToast;
                await Services.Push.SendAsync(message, userID);
            }
            catch (Exception e)
            {
                Services.Log.Error(e.ToString());
            }
        }
    }
}