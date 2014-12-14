using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure;
using System.Configuration;

namespace FoodCalMobileBackend.Controllers
{
    /// <summary>
    /// This class manage the creation and deletion of all the storage tables
    /// </summary>
    public class StorageTableController : ApiController
    {
        public ApiServices Services { get; set; }
        CloudStorageAccount storageAccount = null;
        CloudTableClient tableClient = null;

        public void Initializer() {
            if (storageAccount == null)
            {
                storageAccount = CloudStorageAccount.Parse(
                    ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
            }
            if (tableClient == null)
            {
                tableClient = storageAccount.CreateCloudTableClient();
            }
        }

        // GET api/StorageTable
        public string Get()
        {
            Services.Log.Info("Hello from custom controller!");
            return "Hello";
        }

        public void CreateTable(string name)
        {
            Initializer();

            // Create the table if it doesn't exist.
            CloudTable table = tableClient.GetTableReference("name");
            table.CreateIfNotExists();
        }

        public void DeleteTable(string name)
        {
            Initializer();

        }
    }
}
