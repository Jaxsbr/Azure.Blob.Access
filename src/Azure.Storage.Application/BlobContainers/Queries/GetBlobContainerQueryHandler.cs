using Azure.Storage.Application.BlobContainers.Models;
using Azure.Storage.Domain.Entities;
using Azure.Storage.Persistence;
using MediatR;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Application.BlobContainers.Queries
{
    public class GetBlobContainerQueryHandler : IRequestHandler<GetBlobContainerQuery, BlobContainerViewModel>
    {
        private readonly IStorageAccount _storageAccount;
        private readonly CloudBlobClient _cloudBlobClient;


        public GetBlobContainerQueryHandler(IStorageAccount storageAccount)
        {
            _storageAccount = storageAccount;
            _cloudBlobClient = _storageAccount.GetCloudBlobClient();
        }


        public async Task<BlobContainerViewModel> Handle(GetBlobContainerQuery request, CancellationToken cancellationToken)
        {      
            var blobContainer = _cloudBlobClient.GetContainerReference(request.Name);

            if (request.CreateIfNotExists)
            {
                await blobContainer.CreateIfNotExistsAsync();
            }

            await blobContainer.FetchAttributesAsync();

            return new BlobContainerViewModel
            {
                BlobContainer = BlobContainerDto.Create(new BlobContainer
                {
                    Name = blobContainer.Name,
                    LastModified = Convert.ToDateTime(blobContainer.Properties.LastModified.ToString()),
                }),
                DeleteEnabled = true,
                EditEnabled = true
            };
        }
    }
}
