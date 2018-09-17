using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Application.BlobContainers.Models
{
    public class BlobContainersListViewModel
    {
        public BlobContainersListViewModel()
        {
            BlobContainers = new List<BlobContainerDto>();
        }
        

        public List<BlobContainerDto> BlobContainers { get; set; }
        public bool CreateEnabled { get; set; }
    }
}
