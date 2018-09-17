using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Storage.Persistence
{
    public interface IStorageAccount
    {
        CloudBlobClient GetCloudBlobClient();
        CloudQueueClient GetCloudQueueClient();   
    }
}
