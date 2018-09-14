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
        private readonly IStorageAccount _storageAccount;
        private readonly CloudBlobClient _cloudBlobClient;

        public BlobContainerRepository(IStorageAccount storageAccount)
        {
            _storageAccount = storageAccount;
            _cloudBlobClient = _storageAccount.GetCloudBlobClient();
        }

        public async Task CreateNewBlobContainer(IBlobContainer blobContainer)
        {
            var blobContainerReference = _cloudBlobClient.GetContainerReference(blobContainer.Name);            

            var exists = await blobContainerReference.ExistsAsync();

            if (!exists)
            {
                await blobContainerReference.CreateAsync(blobContainer.PublicAccessType, blobContainer.RequestOptions, blobContainer.OperationContext);
            }
        }

        public Task DeleteBlobContainer(IBlobContainer blobContainer)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IBlobContainer>> GetAllBlobContainers()
        {
            BlobContinuationToken continuationToken = null;

            List<CloudBlobContainer> results = new List<CloudBlobContainer>();

            List<IBlobContainer> blobContainers = new List<IBlobContainer>();

            do
            {
                var response = await _cloudBlobClient.ListContainersSegmentedAsync(continuationToken);

                continuationToken = response.ContinuationToken;

                results.AddRange(response.Results);
            }
            while (continuationToken != null);

            foreach (var container in results)
            {
                await container.FetchAttributesAsync();

                blobContainers.Add(new BlobContainer()
                {
                    Name = container.Name,
                    LastModified = Convert.ToDateTime(container.Properties.LastModified.ToString()),
                });
            }

            return blobContainers;
        }

        public async Task<IBlobContainer> GetBlobContainerByName(string name, bool createIfNotExists)
        {
            var blobContainer = _cloudBlobClient.GetContainerReference(name);

            if (createIfNotExists)
            {
                await blobContainer.CreateIfNotExistsAsync();
            }

            await blobContainer.FetchAttributesAsync();

            return new BlobContainer()
            {
                Name = blobContainer.Name,
                LastModified = Convert.ToDateTime(blobContainer.Properties.LastModified.ToString()),
            };
        }

        public Task EditBlobContainer(IBlobContainer blobContainer)
        {
            throw new NotImplementedException();
        }
    }
}
