using MediatR;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Application.CloudTables.Commands
{
    public class CreateCloudTableCommand : IRequest<CloudTable>
    {
        public string Name { get; set; }
    }
}
