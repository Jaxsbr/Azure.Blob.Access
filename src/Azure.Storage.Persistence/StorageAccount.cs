using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Azure.Storage.Persistence
{
    public class StorageAccount : IStorageAccount
    {
        private readonly CloudStorageAccount _cloudStorageAccount;

        public StorageAccount(string connectionString)
        {
            _cloudStorageAccount = CloudStorageAccount.Parse(connectionString);
        }


        public CloudBlobClient GetCloudBlobClient()
        {
            return _cloudStorageAccount.CreateCloudBlobClient();
        }

        public CloudQueueClient GetCloudQueueClient()
        {
          return _cloudStorageAccount.CreateCloudQueueClient();
        }
    }
}
