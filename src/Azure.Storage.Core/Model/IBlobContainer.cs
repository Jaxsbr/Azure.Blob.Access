using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.BlobAccess.Core.Model
{
    public interface IBlobContainer
    {
        string Name { get; set; }
        DateTime LastModified { get; set; }
        BlobContainerPublicAccessType PublicAccessType { get; set; }
        BlobRequestOptions RequestOptions { get; set; }
        Microsoft.WindowsAzure.Storage.OperationContext OperationContext { get; set; }
    }
}
