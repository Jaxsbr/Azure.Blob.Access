using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.BlobAccess.Core.Model
{
    public interface IBlobContainer
    {
        string Name { get; set; }
        DateTime LastModified { get; set; }
    }
}
