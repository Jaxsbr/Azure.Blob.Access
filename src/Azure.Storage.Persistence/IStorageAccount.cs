using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;
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
        CloudTableClient GetCloudTableClient();
    }
}
