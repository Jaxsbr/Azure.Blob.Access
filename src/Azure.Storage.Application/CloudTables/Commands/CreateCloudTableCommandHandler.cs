using Azure.Storage.Persistence;
using MediatR;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Application.CloudTables.Commands
{
    public class CreateCloudTableCommandHandler : IRequestHandler<CreateCloudTableCommand, CloudTable>
    {
        private readonly IStorageAccount _storageAccount;
        private readonly IMediator _mediator;
        private readonly CloudTableClient _cloudTableClient;

        public CreateCloudTableCommandHandler(IStorageAccount storageAccount, IMediator mediator)
        {
            _storageAccount = storageAccount;

            _mediator = mediator;

            _cloudTableClient = _storageAccount.GetCloudTableClient();
        }

        public async Task<CloudTable> Handle(CreateCloudTableCommand request, CancellationToken cancellationToken)
        {
            var cloudTableReference = _cloudTableClient.GetTableReference(request.Name);

            var exists = await cloudTableReference.ExistsAsync();

            if (!exists)
            {
                await cloudTableReference.CreateAsync();
            }

            return cloudTableReference;
        }
    }
}
