using Azure.Storage.Application.BlobContainers.Models;
using Azure.Storage.Domain.Entities;
using Azure.Storage.Persistence;
using MediatR;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Application.BlobContainers.Queries
{
    public class GetAllBlobContainersQueryHandler : IRequestHandler<GetAllBlobContainersQuery, BlobContainersListViewModel>
    {
        private readonly IStorageAccount _storageAccount;
        private readonly CloudBlobClient _cloudBlobClient;

        public GetAllBlobContainersQueryHandler(IStorageAccount storageAccount)
        {
            _storageAccount = storageAccount;
            _cloudBlobClient = _storageAccount.GetCloudBlobClient();
        }

        public async Task<BlobContainersListViewModel> Handle(GetAllBlobContainersQuery request, CancellationToken cancellationToken)
        {
            BlobContinuationToken continuationToken = null;

            var results = new List<CloudBlobContainer>();

            var blobContainers = new List<BlobContainer>();

            var model = new BlobContainersListViewModel { CreateEnabled = true };

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

                model.BlobContainers.Add(
                    BlobContainerDto.Create(
                        new BlobContainer
                        {
                            Name = container.Name,
                            LastModified = Convert.ToDateTime(container.Properties.LastModified.ToString()),
                        }));
            }
            
            return model;
        }
    }
}
