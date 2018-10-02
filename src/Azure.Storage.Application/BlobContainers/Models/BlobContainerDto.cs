using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Azure.Storage.Domain.Entities;
using Azure.Storage.Domain.Enums;

namespace Azure.Storage.Application.BlobContainers.Models
{
    public class BlobContainerDto
    {
        public string Name { get; set; }
        public DateTime LastModified { get; set; }
        public BlobContainerAccessType AccessType { get;set; }

        
        public static Expression<Func<BlobContainer, BlobContainerDto>> Projection
        {
            get
            {
                return p => new BlobContainerDto
                {
                  Name = p.Name,
                  LastModified = p.LastModified
                };
            }
        }

        public static BlobContainerDto Create(BlobContainer blobContainer)
        {
            return Projection.Compile().Invoke(blobContainer);
        }
    }
}
