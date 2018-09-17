using Azure.Storage.Application.BlobContainers.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Application.BlobContainers.Command
{
    public class CreateBlobContainerCommand : IRequest<BlobContainerViewModel>
    {
        public string Name { get; set; }
        public bool IsPublic { get; set; }
    }
}
