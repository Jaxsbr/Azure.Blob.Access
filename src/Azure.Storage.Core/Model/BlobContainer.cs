using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.BlobAccess.Core.Model
{
    public class BlobContainer : IBlobContainer
    {
        public string Name { get; set; }
        public DateTime LastModified { get; set; }
        public BlobContainerPublicAccessType PublicAccessType { get; set; }
        public BlobRequestOptions RequestOptions { get; set; }
        public OperationContext OperationContext { get; set; }
  }
}
