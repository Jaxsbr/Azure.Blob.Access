using Azure.Storage.Application.BlobContainers.Models;
using Azure.Storage.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Application.BlobContainers.Command
{
    public class DeleteBlobContainerCommand : IRequest
    {
        public string Name { get; set; }
    }
}
