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

namespace Azure.Storage.Application.BlobContainers.Commands
{
    public class CreateBlobContainerCommandHandler : IRequestHandler<CreateBlobContainerCommand, BlobContainerViewModel>
    {
        private readonly IStorageAccount _storageAccount;
        private readonly IMediator _mediator;
        private readonly CloudBlobClient _cloudBlobClient;

        public CreateBlobContainerCommandHandler(IStorageAccount storageAccount, IMediator mediator)
        {
            _storageAccount = storageAccount;

            _mediator = mediator;

            _cloudBlobClient = _storageAccount.GetCloudBlobClient();
        }


        public async Task<BlobContainerViewModel> Handle(CreateBlobContainerCommand request, CancellationToken cancellationToken)
        {
            var blobContainerReference = _cloudBlobClient.GetContainerReference(request.Name);

            var exists = await blobContainerReference.ExistsAsync();

            if (!exists)
            {
                var publicAccessType = (BlobContainerPublicAccessType)request.AccessType;
                
                await blobContainerReference.CreateAsync(publicAccessType, new BlobRequestOptions(), new Microsoft.WindowsAzure.Storage.OperationContext());
            }

            return await _mediator.Send(new GetBlobContainerQuery(request.Name, false));
        }
    }
}
