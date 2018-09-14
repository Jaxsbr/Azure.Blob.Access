using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.BlobAccess.Core.Model
{
    public class BlobContainer : IBlobContainer
    {
        public string Name { get; set; }
        public DateTime LastModified { get; set; }
    }
}
