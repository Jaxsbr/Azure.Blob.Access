using Azure.Storage.Application.BlobContainers.Models;
using Azure.Storage.Application.BlobContainers.Queries;
using Azure.Storage.Persistence;
using MediatR;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Application.BlobContainers.Command
{
    public class UpdateBlobContainerCommandHandler : IRequestHandler<UpdateBlobContainerCommand, BlobContainerViewModel>
    {
        private readonly IStorageAccount _storageAccount;
        private readonly IMediator _mediator;
        private readonly CloudBlobClient _cloudBlobClient;

        public UpdateBlobContainerCommandHandler(IStorageAccount storageAccount, IMediator mediator)
        {
            _storageAccount = storageAccount;

            _mediator = mediator;

            _cloudBlobClient = _storageAccount.GetCloudBlobClient();
        }

        public async Task<BlobContainerViewModel> Handle(UpdateBlobContainerCommand request, CancellationToken cancellationToken)
        {
            var blobContainerReference = _cloudBlobClient.GetContainerReference(request.Name);

            var exists = await blobContainerReference.ExistsAsync();

            if (!exists)
            {
                return null;
            }

            // TODO: Override blobContainer with request

            throw new NotImplementedException();
        }
    }
}
