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
    public class DeleteBlobContainerCommandHandler : IRequestHandler<DeleteBlobContainerCommand>
    {
        private readonly IStorageAccount _storageAccount;
        private readonly IMediator _mediator;
        private readonly CloudBlobClient _cloudBlobClient;

        public DeleteBlobContainerCommandHandler(IStorageAccount storageAccount, IMediator mediator)
        {
            _storageAccount = storageAccount;

            _mediator = mediator;

            _cloudBlobClient = _storageAccount.GetCloudBlobClient();
        }
    
        public async Task<Unit> Handle(DeleteBlobContainerCommand request, CancellationToken cancellationToken)
        {
            var blobContainerReference = _cloudBlobClient.GetContainerReference(request.Name);

            await blobContainerReference.DeleteIfExistsAsync();            

            return Unit.Value;
        }
  }
}
