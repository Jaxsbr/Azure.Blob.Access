using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.BlobAccess.Core.Domain
{
    public interface IStorageAccount
    {
        CloudBlobClient GetCloudBlobClient();
    }
}
