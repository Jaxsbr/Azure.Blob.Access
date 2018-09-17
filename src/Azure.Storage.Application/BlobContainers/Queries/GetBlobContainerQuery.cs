using Azure.Storage.Application.BlobContainers.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Application.BlobContainers.Queries
{
    public class GetBlobContainerQuery : IRequest<BlobContainerViewModel>
    {
        public GetBlobContainerQuery()
        {

        }

        public GetBlobContainerQuery(string name, bool createIfNotExists)
        {
            Name = name;
            CreateIfNotExists = createIfNotExists;
        }

        public string Name { get; set; }

        public bool CreateIfNotExists { get; set; }
    }
}
