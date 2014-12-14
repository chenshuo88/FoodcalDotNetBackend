using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using FoodCalMobileBackend.DataObjects;

namespace FoodCalMobileBackend.Controllers
{
    public class UserProfileBlobController : ApiController
    {
        public ApiServices Services { get; set; }

        // GET api/UserProfileBlob
        public string Get()
        {
            Services.Log.Info("Hello from custom controller!");
            return "Hello";
        }

        public void uploadPicture(UserProfile item)
        {
            // Insert the user profile picture into the Azure Blob storage
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(this.Services.Settings["STORAGE_CONNECTION_STRING"]);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("userprofilepicture");
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

        }
    }
}
