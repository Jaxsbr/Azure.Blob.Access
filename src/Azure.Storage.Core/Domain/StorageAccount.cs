using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Azure.BlobAccess.Core.Domain
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
    }
}
