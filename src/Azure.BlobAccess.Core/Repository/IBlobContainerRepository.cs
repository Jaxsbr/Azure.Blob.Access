using Azure.BlobAccess.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Azure.BlobAccess.Core.Repository
{
    public interface IBlobContainerRepository
    {
        Task<IEnumerable<IBlobContainer>> GetAllBlobContainers();
        Task<IBlobContainer> GetBlobContainerByName(string name);
        Task CreateNewBlobContainer(IBlobContainer blobContainer);
        Task RenameBlobContainer(IBlobContainer blobContainer, string name);
        Task DeleteBlobContainer(IBlobContainer blobContainer);
    }
}
