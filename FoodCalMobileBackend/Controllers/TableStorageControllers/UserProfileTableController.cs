using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FoodCalMobileBackend.Models;

using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;
using System.Web.Http.OData;

namespace FoodCalMobileBackend.Controllers
{
    public class UserProfileTableController : ApiController
    {
        public ApiServices Services { get; set; }

        CloudStorageAccount storageAccount = null;
        CloudTableClient tableClient = null;
        CloudTable table = null;

        public void Initialize()
        {
            try
            {
                if (storageAccount == null)
                {
                    var con = ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString;
                    storageAccount = CloudStorageAccount.Parse(con);
                }
                if (tableClient == null)
                {
                    tableClient = storageAccount.CreateCloudTableClient();
                    table = tableClient.GetTableReference("UserProfile");
                    table.CreateIfNotExists();
                }

            }
            catch (Exception ex)
            {
                Services.Log.Info("Exception " + ex.Message + " is encountered.");
            }
        }

        // GET api/UserProfileTable/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public async Task<UserProfileEntity> GetUserProfile(string name, string id)
        {
            Initialize();

            //// Create the table query.
            //TableQuery<UserProfileEntity> rangeQuery = new TableQuery<UserProfileEntity>().Where(
            //    TableQuery.CombineFilters(
            //        TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, name),
            //        TableOperators.And,
            //        TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, id)));

            //// Loop through the results, displaying information about the entity.
            //foreach (UserProfileEntity entity in table.ExecuteQuery(rangeQuery))
            //{
            //    return entity;
            //} 
            try
            {
                TableOperation retrieveOperation = TableOperation.Retrieve<UserProfileEntity>(name, id);
                TableResult retrievedResult = await table.ExecuteAsync(retrieveOperation);

                if (retrievedResult.Result != null)
                {
                    return (UserProfileEntity)retrievedResult.Result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Services.Log.Info("Exception " + ex.Message + " is encountered.");
            }
            return null;
        }

        // PATCH api/UserProfile/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public async Task<IHttpActionResult> PatchUserProfile(string name, string id, Delta<UserProfileEntity> patch)
        {
            Initialize();

            try
            {
                Services.Log.Info("User " + patch.GetEntity().PartitionKey + " has been updated.");
                TableOperation retrieveOperation = TableOperation.Retrieve<UserProfileEntity>(name, id);
                TableResult retrievedResult = await table.ExecuteAsync(retrieveOperation);
                UserProfileEntity updateEntity = (UserProfileEntity)retrievedResult.Result;

                if (updateEntity != null)
                {
                    patch.Patch(updateEntity);
                    // Create the InsertOrReplace TableOperation
                    TableOperation insertOrReplaceOperation = TableOperation.InsertOrReplace(updateEntity);

                    // Execute the operation.
                    await table.ExecuteAsync(insertOrReplaceOperation);
                    Services.Log.Info("Entity updated.");
                    return new CreateTableEntityActionResult(
                       Request,
                       Url.Link("DefaultApi", new { controller = "UserProfile", id = id })
                   );
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound); 
                }
            }
            catch (Exception ex)
            {
                Services.Log.Info("Exception " + ex.Message + " is encountered.");
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable); 
            }

        }

        // POST api/UserProfile
        public async Task PostUserProfile(string name, string id, UserProfileEntity item)
        {
            Initialize();

            try
            {
                Services.Log.Info("User " + item.PartitionKey + " has been updated.");
                TableOperation retrieveOperation = TableOperation.Retrieve<UserProfileEntity>(name, id);
                TableResult retrievedResult = table.Execute(retrieveOperation);
                UserProfileEntity updateEntity = (UserProfileEntity)retrievedResult.Result;

                // Create the InsertOrReplace TableOperation
                TableOperation insertOrReplaceOperation = TableOperation.InsertOrReplace(item);

                // Execute the operation.
                await table.ExecuteAsync(insertOrReplaceOperation);
                Services.Log.Info("New entity inserted.");

            }
            catch (Exception ex)
            {
                Services.Log.Info("Exception " + ex.Message + " is encountered.");
            }

        }

        // DELETE api/UserProfile/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public async Task DeleteUserProfile(string name, string id)
        {
            Initialize();

            try
            {
                Services.Log.Info("User " + id + " has been deleted from our system.");

                TableOperation retrieveOperation = TableOperation.Retrieve<UserProfileEntity>(name, id);
                TableResult retrievedResult = await table.ExecuteAsync(retrieveOperation);
                UserProfileEntity deleteEntity = (UserProfileEntity)retrievedResult.Result;
                if (deleteEntity != null)
                {
                    TableOperation deleteOperation = TableOperation.Delete(deleteEntity);
                    

                    // Execute the operation.
                    await table.ExecuteAsync(deleteOperation);
                    Services.Log.Info("Entity deleted.");
                }
            }
            catch (Exception ex)
            {
                Services.Log.Info("Exception " + ex.Message + " is encountered.");
            }

        }
    }
}
