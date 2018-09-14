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
        Task<IBlobContainer> GetBlobContainerByName(string name, bool createIfNotExists);
        Task CreateNewBlobContainer(IBlobContainer blobContainer);
        Task EditBlobContainer(IBlobContainer blobContainer);
        Task DeleteBlobContainer(IBlobContainer blobContainer);
    }
}
