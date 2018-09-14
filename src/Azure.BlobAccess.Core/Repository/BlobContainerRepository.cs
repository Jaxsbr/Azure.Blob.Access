using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.BlobAccess.Core.Domain;
using Azure.BlobAccess.Core.Model;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Azure.BlobAccess.Core.Repository
{
    public class BlobContainerRepository : IBlobContainerRepository
    {
        private readonly IStorageAccount _storeageAccount;
        private readonly CloudBlobClient _cloudBlobClient;


        public BlobContainerRepository(IStorageAccount storageAccount)
        {
            _storeageAccount = storageAccount;
            _cloudBlobClient = _storeageAccount.GetCloudBlobClient();
        }

        public Task CreateNewBlobContainer(IBlobContainer blobContainer)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBlobContainer(IBlobContainer blobContainer)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IBlobContainer>> GetAllBlobContainers()
        {
            throw new NotImplementedException();
        }

        public Task<IBlobContainer> GetBlobContainerByName()
        {
            throw new NotImplementedException();
        }

        public Task RenameBlobContainer(IBlobContainer blobContainer, string name)
        {
            throw new NotImplementedException();
        }
    }
}
