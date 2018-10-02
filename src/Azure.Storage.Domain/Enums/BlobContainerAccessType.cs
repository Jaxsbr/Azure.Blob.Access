using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Domain.Enums
{
    public enum BlobContainerAccessType
    {
        Off = 0,        // No public access
        Container = 1,  // Public access to blob container and blob data
        Blob = 2,       // Public access to blob data only
        Unknown = 3     // Un catered for enum value
    }
}
