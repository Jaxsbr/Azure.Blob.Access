using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Application.BlobContainers.Models
{
    public class BlobContainerViewModel
    {
        public BlobContainerDto BlobContainer { get; set; }
        public bool EditEnabled { get; set; }
        public bool DeleteEnabled { get; set; }        
    }
}
