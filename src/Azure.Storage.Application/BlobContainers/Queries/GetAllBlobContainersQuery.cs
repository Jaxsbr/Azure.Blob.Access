using Azure.Storage.Application.BlobContainers.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Application.BlobContainers.Queries
{
    public class GetAllBlobContainersQuery : IRequest<BlobContainersListViewModel>
    {
    }
}
